import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  box: {
    marginTop: 8,
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  container: {
    marginTop: "150px",
    border: "1px solid #ccc",
    borderRadius: "10px",
  },
}));

export default useStyles;
