import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  main: {
    margin: 0,
    padding: 0,
    display: "flex",
    flexDirection: "column",
    minHeight: "97vh",
  },
  content: {
    flexGrow: 1,
  },
  header: {
    height: "80px",
  },
  footer: {
    textAlign: "center",
    margin: "10px 0",
    variant: "overline",
    display: "block",
    fontSize: "12px",
    a: {
      textDecoration: "none",
      color: "inherit",
      fontWeight: "bold",
    },
  },
}));

export default useStyles;
