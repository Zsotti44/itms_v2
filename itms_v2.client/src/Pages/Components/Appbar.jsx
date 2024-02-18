import * as React from "react";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import Divider from "@mui/material/Divider";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import List from "@mui/material/List";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import DashboardIcon from "@mui/icons-material/Dashboard";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import PeopleIcon from "@mui/icons-material/People";
import BarChartIcon from "@mui/icons-material/BarChart";
import Typography from "@mui/material/Typography";
import MuiAppBar from "@mui/material/AppBar";
import MuiDrawer from "@mui/material/Drawer";
import { styled } from "@mui/material/styles";
import Toolbar from "@mui/material/Toolbar";
import LocalShippingIcon from '@mui/icons-material/LocalShipping';
import RvHookupIcon from '@mui/icons-material/RvHookup';
import { Link } from 'react-router-dom';
import BrowseGalleryIcon from '@mui/icons-material/BrowseGallery';

const drawerWidth = 240;
const AppBar = styled(MuiAppBar, {
    shouldForwardProp: (prop) => prop !== "open",
  })(({ theme, open }) => ({
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(["width", "margin"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
      marginLeft: drawerWidth,
      width: `calc(100% - ${drawerWidth}px)`,
      transition: theme.transitions.create(["width", "margin"], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
    }),
  }));
  const Drawer = styled(MuiDrawer, {
    shouldForwardProp: (prop) => prop !== "open",
  })(({ theme, open }) => ({
    "& .MuiDrawer-paper": {
      position: "relative",
      whiteSpace: "nowrap",
      width: drawerWidth,
      transition: theme.transitions.create("width", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
      boxSizing: "border-box",
      ...(!open && {
        overflowX: "hidden",
        transition: theme.transitions.create("width", {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        width: theme.spacing(7),
        [theme.breakpoints.up("sm")]: {
          width: theme.spacing(9),
        },
      }),
    },
  }));

const Navigation_bar = () => {
    const [open, setOpen] = React.useState(true);
    const toggleDrawer = () => {
      setOpen(!open);
    };
  
    return (<>
<AppBar position="absolute" open={open}>
<Toolbar
  sx={{
    pr: "24px",
  }}
>
  <IconButton
    edge="start"
    color="inherit"
    aria-label="open drawer"
    onClick={toggleDrawer}
    sx={{
      marginRight: "36px",
      ...(open && { display: "none" }),
    }}
  >
    <MenuIcon />
  </IconButton>
  <Typography
    component="h1"
    variant="h6"
    color="inherit"
    noWrap
    sx={{ flexGrow: 1 }}
  >
    Vontatók
  </Typography>
</Toolbar>
</AppBar>
<Drawer variant="permanent" open={open}>
<Toolbar
  sx={{
    display: "flex",
    alignItems: "center",
    justifyContent: "flex-end",
    px: [1],
  }}
>
  <IconButton onClick={toggleDrawer}>
    <ChevronLeftIcon />
  </IconButton>
</Toolbar>
<Divider />
<List component="nav">
  <React.Fragment>
    <ListItemButton component={Link} to="/">
      <ListItemIcon>
        <DashboardIcon />
      </ListItemIcon>
      <ListItemText primary="Vezérlőpult" />
    </ListItemButton>
    <ListItemButton component={Link} to="/worktickets">
      <ListItemIcon>
        <ShoppingCartIcon />
      </ListItemIcon>
      <ListItemText primary="Munkák" />
    </ListItemButton>
    <ListItemButton component={Link} to="/reports">
      <ListItemIcon>
        <BarChartIcon />
      </ListItemIcon>
      <ListItemText primary="Jelentések" />
    </ListItemButton>

    <Divider />
    <ListItemButton component={Link} to="/shifts">
      <ListItemIcon>
        <BrowseGalleryIcon />
      </ListItemIcon>
      <ListItemText primary="Műszakok" />
    </ListItemButton>
    <ListItemButton component={Link} to="/truckDrivers">
      <ListItemIcon>
        <PeopleIcon />
      </ListItemIcon>
      <ListItemText primary="Gépjárművezetők" />
    </ListItemButton>
    <ListItemButton component={Link} to="/trucks">
      <ListItemIcon>
        <LocalShippingIcon />
      </ListItemIcon>
      <ListItemText primary="Vontatók" />
    </ListItemButton>
    <ListItemButton  component={Link} to="/trailers">
      <ListItemIcon>
        <RvHookupIcon />
      </ListItemIcon>
      <ListItemText primary="Pótkocsik" />
    </ListItemButton>
  </React.Fragment>
</List>
</Drawer></>
    );
}

export default Navigation_bar;