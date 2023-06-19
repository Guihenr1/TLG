import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  logo: {
    cursor: "pointer",
    fontWeight: "bold",
  },
  link: {
    textDecoration: "none",
    color: "black",
    width: "100%",
  },
}));

export default useStyles;
