import { FC } from "react";
import useStyles from "./styles";
import { Box, CircularProgress } from "@mui/material";

interface LoadingProps {}

const Loading: FC<LoadingProps> = () => {
  const s = useStyles();

  return (
    <Box className={s.classes.progress}>
      <CircularProgress className={s.classes.icon} />
    </Box>
  );
};

Loading.defaultProps = {};

export default Loading;
