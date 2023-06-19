import { Meta } from "@storybook/react";
import Loading from "./Loading";

export default {
  component: Loading,
  args: {},
} as Meta;

export const Template = (args: any) => <Loading {...args} />;
