import React, { useState, useEffect } from "react";
import axios from "axios";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Snackbar, Button, Typography, TextField } from "@mui/material";

const style = {
  container: {
    maxWidth: "500px",
    margin: " 50px auto",
    textAlign: "center",
    display: "flex",
    flexDirection: "column",
  },
  submitBtn: {},
  unitInput: {
    height: "50px",
  },
};

const EditIngredient = () => {
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const token = sessionStorage.getItem("token");
  const [input, setInput] = useState({
    name: "",
    purchaseQuantity: "",
    purchasePrice: "",
    purchaseUnit: "",
  });
  const units = ["g", "ml", "kg", "l", "pcs"];

  const { id } = useParams();
  useEffect(() => {
    getDetails(id);
    // eslint-disable-next-line
  }, []);

  async function getDetails(id) {
    await axios
      .get(`https://localhost:5001/Ingredients/${id}`)
      .then((res) => {
        // console.log(res.data.data);
        setInput({
          name: res.data.data.name,
          purchaseQuantity: res.data.data.purchaseQuantity,
          purchasePrice: res.data.data.purchasePrice,
          purchaseUnit: res.data.data.purchaseUnit,
        });
      })
      .catch((err) => console.log(err.message));
  }
  const handleCloseSnackbar = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setOpenSnackbar(false);
  };
  function onChange(e) {
    setInput({ ...input, [e.target.name]: e.target.value });
  }

  async function editIngredient(e) {
    e.preventDefault();
    await axios
      .put(`https://localhost:5001/Ingredients/${id}`, input, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      })
      .then((res) => {
        setMessage(res.data.message);
        setOpenSnackbar(true);
        setTimeout(() => {
          navigate(`/ingredients`);
        }, 1000);
      })
      .catch((err) => console.log(err.message));
  }
  const onlyPositive = (e) => {
    ["e", "E", "-", "+"].includes(e.key) && e.preventDefault();
  };
  return (
    <Box component="form" sx={style.container} onSubmit={editIngredient}>
      <Typography>Name</Typography>
      <TextField value={input.name} name="name" onChange={onChange} required />
      <Typography>Quantity</Typography>
      <TextField
        value={input.purchaseQuantity}
        name="purchaseQuantity"
        onKeyDown={onlyPositive}
        onChange={onChange}
        required
      />
      <Typography>Price</Typography>
      <TextField
        value={input.purchasePrice}
        name="purchasePrice"
        onKeyDown={onlyPositive}
        onChange={onChange}
        required
      />
      <Typography>Unit</Typography>
      <select
        style={style.unitInput}
        required
        value={input.purchaseUnit}
        name="purchaseUnit"
        onChange={onChange}
      >
        {units.map((item) => (
          <option key={item}>{item}</option>
        ))}
      </select>
      <Button type="submit">edit</Button>
      <Snackbar
        open={openSnackbar}
        autoHideDuration={1000}
        onClose={handleCloseSnackbar}
        message={message}
      />
    </Box>
  );
};

export default EditIngredient;
