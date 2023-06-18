import { FC } from "react";
import CardMui from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import FavoriteIcon from "@mui/icons-material/Favorite";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import useStyles from "./styles";

interface CardProps {
  id: string;
  title: string;
  image: string;
  description: string;
  handleFavorite: Function;
  favorite: boolean;
}

const Card: FC<CardProps> = ({
  id,
  title,
  image,
  description,
  handleFavorite,
  favorite,
}) => {
  const s = useStyles();

  return (
    <CardMui className={s.classes.card} sx={{ maxWidth: 345 }}>
      <CardHeader title={title} />
      <CardMedia component="img" height="194" image={image} />
      <CardContent>
        <Typography variant="body2" color="text.secondary">
          {description}
        </Typography>
      </CardContent>
      <CardActions disableSpacing>
        <IconButton
          aria-label="add to favorites"
          onClick={() => handleFavorite(id)}
          title="add to favorites"
        >
          {favorite ? <FavoriteIcon /> : <FavoriteBorderIcon />}
        </IconButton>
      </CardActions>
    </CardMui>
  );
};

Card.defaultProps = {};

export default Card;
