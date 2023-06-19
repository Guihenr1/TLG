import { makeStyles } from "tss-react/mui";

const useStyles = makeStyles()(() => ({
  progress: {
    display: "flex",
  },
  icon: {
    color: "black",
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
  },
}));

export default useStyles;
