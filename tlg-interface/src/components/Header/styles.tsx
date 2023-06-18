import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  header: {
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
    width: "100%",
  },
  margin: {
    marginLeft: "auto",
  },
  logo: {
    cursor: "pointer",
    fontWeight: "bold",
  },
  menu: {
    background: "transparent",
    border: "none",
    boxShadow: "none",
    borderBottom: "1px solid #ccc",
  },
  link: {
    textDecoration: "none",
    color: "black",
  },
  menuMobile: {
    cursor: "pointer",
  },
}));

export default useStyles;
