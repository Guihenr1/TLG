import { FC, useEffect, useState } from "react";
import useStyles from "./styles";
import instance from "../../api/instance";
import { useAuth } from "../../hooks/useAuth";
import { Box, Grid } from "@mui/material";
import Card from "../../components/Card/Card";
import Pagination from "../../components/Pagination/Pagination";
import Loading from "../../components/Loading/Loading";

interface FeedProps {
  wishlist: boolean;
}

interface DataContentProps {
  count: number;
  contents: ContentProps[];
}

interface ContentProps {
  id: string;
  title: string;
  image: string;
  description: string;
  handleFavorite: Function;
  isFavorite: boolean;
}

const Feed: FC<FeedProps> = ({ wishlist }) => {
  const s = useStyles();
  const { user } = useAuth();
  const [loading, setLoading] = useState(false);
  const [data, setData] = useState<DataContentProps>();
  const [page, setPage] = useState(1);

  const fetchData = async () => {
    try {
      const headers = { Authorization: `Bearer ${user.token}` };

      const response = await instance.get(
        `/Content/${
          wishlist ? "get-all-by-wishlist" : "get-all"
        }?pageNumber=${page}&pageSize=12`,
        { headers }
      );

      setData(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    setLoading(true);
    fetchData();
  }, [page]);

  const handleFavorite = async (cardId: string) => {
    setLoading(true);
    const headers = { Authorization: `Bearer ${user.token}` };
    const isFavorite = data?.contents.find(
      (card) => card.id === cardId
    )?.isFavorite;

    if (isFavorite) {
      try {
        await instance.delete(`/Wishlist/remove?contentId=${cardId}`, {
          headers,
        });

        await fetchData();
      } catch (error) {
        console.error("Error:", error);
      } finally {
        setLoading(false);
      }
    } else {
      try {
        await instance.post(`/Wishlist/add?contentId=${cardId}`, null, {
          headers,
        });

        await fetchData();
      } catch (error) {
        console.error("Error:", error);
      } finally {
        setLoading(false);
      }
    }
  };

  const handlePagination = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setPage(value);
  };

  return (
    <>
      {loading ? (
        <Loading />
      ) : (
        <>
          <Grid container spacing={3}>
            {data?.contents.map((value) => (
              <Grid
                key={value.id}
                item
                xs={12}
                sm={6}
                md={4}
                className={s.classes.grid}
              >
                <Card
                  key={value.id}
                  id={value.id}
                  title={value.title}
                  description={value.description}
                  image={value.image}
                  handleFavorite={handleFavorite}
                  favorite={value.isFavorite}
                />
              </Grid>
            ))}
          </Grid>
        </>
      )}
      <Box className={s.classes.pagination}>
        <Pagination
          count={data?.count ? Math.ceil(data?.count / 12) : 0}
          handlePagination={handlePagination}
        />
      </Box>
    </>
  );
};

Feed.defaultProps = {
  wishlist: false,
};

export default Feed;
