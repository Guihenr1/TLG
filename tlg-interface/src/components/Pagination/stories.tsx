import { Meta } from "@storybook/react";
import Pagination from "./Pagination";
import { Box } from "@mui/material";
import { useState } from "react";

export default {
  component: Pagination,
  args: {
    count: 3,
  },
} as Meta;

export const Template = (args: any) => {
  const [page, setPage] = useState({
    page1: false,
    page2: true,
    page3: true,
  });

  const handlePagination = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    const updatedPage = {
      page1: value === 1 ? false : true,
      page2: value === 2 ? false : true,
      page3: value === 3 ? false : true,
    };

    setPage(updatedPage);
  };

  return (
    <>
      <Box hidden={page.page1}>Page 1</Box>
      <Box hidden={page.page2}>Page 2</Box>
      <Box hidden={page.page3}>Page 3</Box>
      <Pagination {...args} handlePagination={handlePagination} />
    </>
  );
};
