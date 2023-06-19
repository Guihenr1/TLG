import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  grid: {
    justifyContent: "center",
    alignItems: "center",
    display: "flex",
  },
  pagination: {
    display: "flex",
    justifyContent: "end",
    padding: "10px 0",
  },
}));

export default useStyles;
