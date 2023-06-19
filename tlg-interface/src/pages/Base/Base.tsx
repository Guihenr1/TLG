import { Navigate, useOutlet } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";
import Header from "../../components/Header/Header";
import { Box, Link, Typography } from "@mui/material";
import useStyles from "./styles";
import { useNavigate } from "react-router-dom";

const Base = () => {
  const navigate = useNavigate();
  const s = useStyles();
  const { user, logout } = useAuth();
  const outlet = useOutlet();

  if (!user) {
    return <Navigate to="/" />;
  }

  const handleClickLogout = () => logout();

  const menu = [
    {
      text: "Feed",
      onClick: () => navigate("/feed"),
    },
    {
      text: "Contact",
      onClick: () => navigate("/contact"),
    },
    {
      text: "Wishlist",
      onClick: () => navigate("/wishlist"),
    },
  ];

  return (
    <Box className={s.classes.main}>
      <Box className={s.classes.header}>
        <Header
          link="/feed"
          handleClickLogout={handleClickLogout}
          menu={menu}
        />
      </Box>
      <Box className={s.classes.content}>{outlet}</Box>
      <Typography gutterBottom className={s.classes.footer}>
        Developed by{" "}
        <Link target="_blank" href="https://github.com/Guihenr1">
          Guilherme Pompilio
        </Link>
      </Typography>
    </Box>
  );
};

export default Base;
