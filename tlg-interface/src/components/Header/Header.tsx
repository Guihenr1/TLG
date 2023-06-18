import { FC, useState } from "react";
import useStyles from "./styles";
import {
  AppBar,
  Box,
  Divider,
  Drawer,
  IconButton,
  Link,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Tab,
  Tabs,
  Toolbar,
  Typography,
  useMediaQuery,
} from "@mui/material";
import LogoutIcon from "@mui/icons-material/Logout";
import MenuIcon from "@mui/icons-material/Menu";

interface Menu {
  text: string;
  onClick: (event: any) => void;
}

interface HeaderProps {
  menu: Menu[];
  handleClickLogout: Function;
}

const Header: FC<HeaderProps> = ({ menu, handleClickLogout }) => {
  const s = useStyles();
  const isMobile = useMediaQuery("(max-width: 600px)");
  const [tab, setTab] = useState(0);
  const [drawer, setDrawer] = useState(false);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setTab(newValue);
  };

  const toggleDrawer =
    (open: boolean) => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === "keydown" &&
        ((event as React.KeyboardEvent).key === "Tab" ||
          (event as React.KeyboardEvent).key === "Shift")
      ) {
        return;
      }

      setDrawer(open);
    };

  return (
    <AppBar color="default" className={s.classes.menu}>
      <Toolbar>
        <Box marginTop={2} marginBottom={2} className={s.classes.header}>
          <Typography className={s.classes.logo} variant="h4">
            <Link href="/" className={s.classes.link}>
              TLG
            </Link>
          </Typography>
          {isMobile ? (
            <>
              <IconButton onClick={toggleDrawer(true)}>
                <MenuIcon className={s.classes.menuMobile} />
              </IconButton>
              <Drawer
                anchor="right"
                open={drawer}
                onClose={toggleDrawer(false)}
              >
                <Box
                  sx={{
                    width: 250,
                  }}
                  role="presentation"
                  onClick={toggleDrawer(false)}
                  onKeyDown={toggleDrawer(false)}
                >
                  <List>
                    {menu.map((item, index) => (
                      <ListItem key={index} disablePadding>
                        <ListItemButton onClick={(e) => item.onClick(e)}>
                          <ListItemText primary={item.text} />
                        </ListItemButton>
                      </ListItem>
                    ))}
                    <Divider />
                    <ListItem disablePadding>
                      <ListItemButton onClick={() => handleClickLogout()}>
                        <ListItemText primary={"Logout"} />
                      </ListItemButton>
                    </ListItem>
                  </List>
                </Box>
              </Drawer>
            </>
          ) : (
            <>
              <Tabs
                className={s.classes.margin}
                value={tab}
                textColor="inherit"
                onChange={handleChange}
                TabIndicatorProps={{ style: { background: "black" } }}
              >
                {menu.map((item, index) => (
                  <Tab
                    label={item.text}
                    key={index}
                    onClick={(e) => item.onClick(e)}
                  />
                ))}
              </Tabs>
              <IconButton
                id="logout"
                color="inherit"
                onClick={() => handleClickLogout()}
              >
                <LogoutIcon />
              </IconButton>
            </>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

Header.defaultProps = {};

export default Header;
