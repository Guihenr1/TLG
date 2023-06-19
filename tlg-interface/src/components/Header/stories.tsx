import { Meta } from "@storybook/react";
import Header from "./Header";

export default {
  component: Header,
  args: {
    handleClickLogout: () => console.log("Logout"),
    menu: [
      {
        text: "Feed",
        onClick: () => console.log("Feed"),
      },
      {
        text: "Contact",
        onClick: () => console.log("Contact"),
      },
      {
        text: "Wishlist",
        onClick: () => console.log("Wishlist"),
      },
    ],
  },
} as Meta;

export const Primary = (args: any) => <Header {...args} />;
