import { Meta } from "@storybook/react";
import Card from "./Card";
import { useState } from "react";

export default {
  component: Card,
  args: {},
} as Meta;

export const Template = (args: any) => {
  const handleFavorite = (cardId: string) => {
    setData((prevData) =>
      prevData.map((card) =>
        card.id === cardId ? { ...card, isFavorite: !card.isFavorite } : card
      )
    );
  };

  const [data, setData] = useState([
    {
      id: "1",
      title: "Title 1",
      image:
        "https://img.freepik.com/free-photo/wood-material-background-wallpaper-texture-concept_53876-42925.jpg?w=900&t=st=1686975509~exp=1686976109~hmac=13db646efe2a6c3bdd7291fe050120c298a684c55cbf179ddcd3f9e60b5f5285",
      description: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae
                    dolor eget sapien semper mattis. Orci varius natoque penatibus et
                    magnis dis parturient montes, nascetur ridiculus mus.`,
      isFavorite: true,
    },
    {
      id: "2",
      title: "Title 2",
      image:
        "https://img.freepik.com/free-photo/fire-flame-black-background_53876-111363.jpg?w=900&t=st=1686975505~exp=1686976105~hmac=fff36e16b670b5f5b7d865a735ef0f1674ac42180bc00080fc5009439128ac22",
      description: `Class aptent taciti sociosqu ad litora torquent per conubia nostra, 
                    per inceptos himenaeos. Vivamus urna leo, convallis eu tellus ac, 
                    rutrum sollicitudin tellus. Donec nec lorem sit amet tellus semper 
                    feugiat lobortis sagittis nisi.`,
      isFavorite: false,
    },
    {
      id: "3",
      title: "Title 3",
      image:
        "https://img.freepik.com/free-photo/wood-material-background-wallpaper-texture-concept_53876-42925.jpg?w=900&t=st=1686975509~exp=1686976109~hmac=13db646efe2a6c3bdd7291fe050120c298a684c55cbf179ddcd3f9e60b5f5285",
      description: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae
                    dolor eget sapien semper mattis. Orci varius natoque penatibus et
                    magnis dis parturient montes, nascetur ridiculus mus.`,
      isFavorite: false,
    },
    {
      id: "4",
      title: "Title 4",
      image:
        "https://img.freepik.com/free-photo/wood-material-background-wallpaper-texture-concept_53876-42925.jpg?w=900&t=st=1686975509~exp=1686976109~hmac=13db646efe2a6c3bdd7291fe050120c298a684c55cbf179ddcd3f9e60b5f5285",
      description: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae
                    dolor eget sapien semper mattis. Orci varius natoque penatibus et
                    magnis dis parturient montes, nascetur ridiculus mus.`,
      isFavorite: false,
    },
    {
      id: "5",
      title: "Title 5",
      image:
        "https://img.freepik.com/free-photo/wood-material-background-wallpaper-texture-concept_53876-42925.jpg?w=900&t=st=1686975509~exp=1686976109~hmac=13db646efe2a6c3bdd7291fe050120c298a684c55cbf179ddcd3f9e60b5f5285",
      description: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae
                    dolor eget sapien semper mattis. Orci varius natoque penatibus et
                    magnis dis parturient montes, nascetur ridiculus mus.`,
      isFavorite: false,
    },
  ]);

  return (
    <>
      {data.map((card) => (
        <Card
          key={card.id}
          id={card.id}
          title={card.title}
          description={card.description}
          image={card.image}
          handleFavorite={handleFavorite}
          favorite={card.isFavorite}
        />
      ))}
    </>
  );
};
