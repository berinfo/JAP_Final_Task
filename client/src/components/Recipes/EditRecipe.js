import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import {
  Box,
  TextField,
  Typography,
  Divider,
  Button,
  Snackbar,
} from "@mui/material";
const style = {
  recipe: {
    margin: "auto",
    textAlign: "center",
    maxWidth: "500px",
  },
};

const EditRecipe = () => {
  const [message, setMessage] = useState("");
  const token = sessionStorage.getItem("token");
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const navigate = useNavigate();
  const { id } = useParams();
  const [input, setInput] = useState({
    name: "",
    description: "",
    categoryId: "1",
    recommSellingPrice: 0,
    recipeIngredients: [],
  });
  useEffect(() => {
    getDetails(id);
    // eslint-disable-next-line
  }, []);

  const getDetails = async (rId) => {
    axios
      .get(`https://localhost:5001/Recipes/${rId}`, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      })
      .then((res) => {
        setInput({
          name: res.data.data.name,
          description: res.data.data.description,
          recommSellingPrice: +res.data.data.recommSellingPrice,
          categoryId: res.data.data.category.id,
          recipeIngredients: res.data.data.recipeIngredients,
        });
      })
      .catch((err) => {
        console.log(err);
      });
  };
  async function editRecipe(e) {
    e.preventDefault();
    await axios
      .put(`https://localhost:5001/Recipes/${id}`, input)
      .then((res) => {
        setMessage(res.data.message);
        setOpenSnackbar(true);
        setTimeout(() => {
          navigate("/recipes");
        }, 1500);
      })
      .catch((err) => console.log(err.message));
  }
  const handleCloseSnackbar = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setOpenSnackbar(false);
  };
  return (
    <Box component="form" sx={style.recipe} onSubmit={editRecipe}>
      <Typography>Name:</Typography>
      <TextField
        type="text"
        fullWidth
        value={input.name}
        required
        onChange={(e) => setInput({ ...input, name: e.target.value })}
      />
      <Typography>Description:</Typography>
      <TextField
        type="text"
        multiline
        fullWidth
        required
        sx={{ mb: 2 }}
        value={input.description}
        onChange={(e) => setInput({ ...input, description: e.target.value })}
      />
      <TextField
        type="number"
        fullWidth
        label="recommended price"
        value={input.recommSellingPrice}
        onChange={(e) =>
          setInput({ ...input, recommSellingPrice: e.target.value })
        }
      />
      <Divider sx={{ mt: 1 }} />
      <Typography>Ingredients:</Typography>
      {input.recipeIngredients.map((item, i) => {
        return (
          <Typography key={i}>
            {item.ingredient.name} - {item.quantity} {item.unit}
          </Typography>
        );
      })}
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

export default EditRecipe;
