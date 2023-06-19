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
  menu: {
    background: "white",
    border: "none",
    boxShadow: "none",
    borderBottom: "1px solid #ccc",
  },
  menuMobile: {
    cursor: "pointer",
  },
}));

export default useStyles;
