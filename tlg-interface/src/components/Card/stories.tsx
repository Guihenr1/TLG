import { Meta } from "@storybook/react";
import Card from "./Card";
import { useState } from "react";
import Pagination from "../Pagination/Pagination";

export default {
  component: Card,
  args: {},
} as Meta;

export const Template = (args: any) => {
  const [data, setData] = useState({
    count: 3,
    contents: [
      {
        id: "b7b929af-0693-4fcf-b237-000b9de53ec8",
        title: "Post 12",
        description:
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit. \n            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et \n            magnis dis parturient montes, nascetur ridiculus mus.",
        image:
          "https://img.freepik.com/free-photo/nature-colorful-landscape-dusk-cloud_1203-5705.jpg?w=900&t=st=1686975519~exp=1686976119~hmac=d6d43d0ed9d2345244142f47d652ccae9f2e105a02af1b7d7bd4feeea2f8936e",
        isFavorite: false,
      },
      {
        id: "de3e0e0a-18d7-43dd-a1fe-4ada10f934da",
        title: "Post 5",
        description:
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit. \n            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et \n            magnis dis parturient montes, nascetur ridiculus mus.",
        image:
          "https://img.freepik.com/free-photo/beige-paintbrush-stroke-textured-background_53876-129531.jpg?w=900&t=st=1686975495~exp=1686976095~hmac=75f79ec572189de466f4365eb0fc99442ba736f734edd7c03c6665dab83b3713",
        isFavorite: true,
      },
      {
        id: "a99232e7-f1c7-40e4-9906-56aafb0e7ce9",
        title: "Post 4",
        description:
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit. \n            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et \n            magnis dis parturient montes, nascetur ridiculus mus.",
        image:
          "https://img.freepik.com/free-photo/authentic-anamorphic-lens-flare-with-ring-ghost-effect_53876-105282.jpg?w=900&t=st=1686975493~exp=1686976093~hmac=717256a795682c9261f29be21a822db57326dabf31a426cadda80e4337fa8858",
        isFavorite: false,
      },
    ],
  });
  const [page, setPage] = useState(0);

  const handleFavorite = (cardId: string) => {
    const updatedContents = data.contents.map((item) => {
      if (item.id === cardId) {
        return { ...item, isFavorite: !item.isFavorite };
      }
      return item;
    });

    setData((prevData) => ({
      ...prevData,
      contents: updatedContents,
    }));
  };

  const handlePagination = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setPage(value - 1);
  };

  return (
    <>
      <Card
        id={data.contents[page].id}
        title={data.contents[page].title}
        description={data.contents[page].description}
        image={data.contents[page].image}
        handleFavorite={handleFavorite}
        favorite={data.contents[page].isFavorite}
      />
      <Pagination count={data.count} handlePagination={handlePagination} />
    </>
  );
};
