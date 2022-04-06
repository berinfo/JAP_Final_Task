import React from "react";
import { useNavigate } from "react-router-dom";
import FoodBankIcon from "@mui/icons-material/FoodBank";
import { Box, Typography, Button } from "@mui/material";

const style = {
  header: {
    backgroundColor: "indigo",
    color: "white",
    heigth: "50px",
    width: "100%",
    display: "flex",
    justifyContent: "space-between",
  },
  logo: {
    cursor: "pointer",
  },
  btn: {
    marginRight: "5px",
    marginTop: "5px",
    variant: "contained",
    color: "white",
    border: "1px solid white",
  },
};

const Header = () => {
  const navigate = useNavigate();
  function logOut() {
    sessionStorage.removeItem("token");
    navigate("/");
  }
  return (
    <Box className="header" sx={style.header}>
      <Box onClick={() => navigate("/categories")} sx={style.logo}>
        <FoodBankIcon />
        <Typography>Normative Calculator App</Typography>
      </Box>
      <Box>
        <Button onClick={() => navigate("/addrecipe")} sx={style.btn}>
          Add
        </Button>
        <Button sx={style.btn} onClick={logOut}>
          Logout
        </Button>
      </Box>
    </Box>
  );
};

export default Header;
