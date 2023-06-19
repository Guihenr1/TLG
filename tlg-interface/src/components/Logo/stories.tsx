import { Meta } from "@storybook/react";
import Logo from "./Logo";

export default {
  component: Logo,
  args: {},
} as Meta;

export const Template = (args: any) => <Logo {...args} />;
