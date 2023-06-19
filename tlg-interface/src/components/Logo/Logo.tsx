import { FC, ReactNode } from "react";
import useStyles from "./styles";
import { Link, Typography } from "@mui/material";

interface LogoProps {
  link?: string;
}

const Logo: FC<LogoProps> = ({ link }) => {
  const s = useStyles();

  return (
    <Typography className={s.classes.logo} variant="h4">
      <Link href={link} className={s.classes.link}>
        TLG
      </Link>
    </Typography>
  );
};

Logo.defaultProps = {
  link: "/",
};

export default Logo;
