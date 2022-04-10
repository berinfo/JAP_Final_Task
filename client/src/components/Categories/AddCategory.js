import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import {
  Box,
  TextField,
  Typography,
  Button,
  Divider,
  Snackbar,
} from "@mui/material";

const style = {
  addCategoryContainer: {
    margin: "10% auto",
    textAlign: "center",
  },
  addBox: {
    display: "flex",
    flexDirection: "column",
    maxWidth: "300px",
    margin: "auto",
    mt: 5,
  },
};

const AddCategory = () => {
  const [name, setName] = useState("");
  const [message, setMessage] = useState("");
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const navigate = useNavigate();
  const token = sessionStorage.getItem("token");

  const handleClick = () => {
    setOpenSnackbar(true);
  };

  const handleCloseSnackbar = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setOpenSnackbar(false);
  };

  async function addCategory() {
    axios
      .post(
        "https://localhost:5001/Categories",
        { name },
        {
          headers: {
            Authorization: `bearer ${token}`,
          },
        }
      )
      .then((res) => {
        setMessage(res.data.message);
        handleClick();
        setTimeout(() => {
          navigate("/categories");
        }, 1500);
      })
      .catch((err) => console.log(err.message));
  }
  return (
    <Box sx={style.addCategoryContainer}>
      <Button onClick={() => navigate(-1)}>back</Button>
      <Typography>Add new category</Typography>
      <Divider />
      <Box sx={style.addBox}>
        <Typography>Name</Typography>
        <TextField value={name} onChange={(e) => setName(e.target.value)} />
        <Button onClick={addCategory}>add</Button>
      </Box>
      <Snackbar
        open={openSnackbar}
        autoHideDuration={1000}
        onClose={handleCloseSnackbar}
        message={message}
      />
    </Box>
  );
};

export default AddCategory;
