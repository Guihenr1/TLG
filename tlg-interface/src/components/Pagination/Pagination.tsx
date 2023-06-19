import { FC, ReactNode } from "react";
import useStyles from "./styles";
import { Stack } from "@mui/material";
import PaginationMui from "@mui/material/Pagination";

interface PaginationProps {
  handlePagination: (event: React.ChangeEvent<unknown>, page: number) => void;
  count: number;
}

const Pagination: FC<PaginationProps> = ({ handlePagination, count }) => {
  const s = useStyles();

  return (
    <Stack spacing={2}>
      <PaginationMui
        onChange={handlePagination}
        count={count}
        shape="rounded"
      />
    </Stack>
  );
};

Pagination.defaultProps = {};

export default Pagination;
