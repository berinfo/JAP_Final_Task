import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { japActions } from "../store";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import {
  Box,
  TextField,
  Button,
  Typography,
  MenuItem,
  Divider,
} from "@mui/material";

const style = {
  container: {
    maxWidth: "500px",
    margin: "5% auto",
  },
  submitBtn: {},
};

const AddRecipe = () => {
  const dispatch = useDispatch();
  const token = sessionStorage.getItem("token");
  const navigate = useNavigate();
  const [message, setMessage] = useState("");
  const [units, setUnits] = useState([]);
  const [prepareIngredients, setPrepareIngredients] = useState([]);
  const [input, setInput] = useState({
    name: "",
    description: "",
    categoryId: "1",
    recipeIngredients: [],
  });
  const [oneIng, setOneIng] = useState({
    ingredientId: 0,
    quantity: 1,
    unit: "",
  });

  useEffect(() => {
    getIngredients();
    // eslint-disable-next-line
  }, []);
  async function getIngredients() {
    await axios
      .get("https://localhost:5001/Ingredients")
      .then((res) => {
        dispatch(japActions.setIngredients(res.data.data));
      })
      .catch((err) => console.log(err));
  }
  const ingredients = useSelector((state) => state.states.ingredients);
  const categories = useSelector((state) => state.states.categories);

  async function create(e) {
    e.preventDefault();
    await axios
      .post("https://localhost:5001/Recipes", input, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      })
      .then(() => {
        setMessage("Created successfully");
        setTimeout(() => {
          navigate("/categories");
        }, 500);
      });
  }

  function onChangeCategory(e) {
    setInput({ ...input, category: e.target.value });
  }
  function onChangeName(e) {
    setInput({ ...input, name: e.target.value });
  }
  function onChangeIngUnit(e) {
    setOneIng({ ...oneIng, unit: e.target.value });
  }

  function addIngredientToArr() {
    prepareIngredients.push(oneIng);
    setInput({ ...input, recipeIngredients: prepareIngredients });
  }

  function ingredientChangeHandler(e) {
    setOneIng({ ...oneIng, ingredientId: e.target.value });
    if (e.target.value == 1 || e.target.value == 5) {
      setUnits(["ml", "l"]);
    }
    if (e.target.value == 6) {
      setUnits(["pcs"]);
    }
    if (
      e.target.value == 2 ||
      e.target.value == 3 ||
      e.target.value == 4 ||
      e.target.value == 7
    ) {
      setUnits(["g", "kg"]);
    }
  }

  return (
    <Box sx={style.container} component="form" onSubmit={create}>
      <Typography>Name:</Typography>
      <TextField
        type="text"
        fullWidth
        value={input.name}
        required
        onChange={onChangeName}
      />
      <Typography>Category:</Typography>
      <TextField
        select
        fullWidth
        onChange={onChangeCategory}
        defaultValue="1"
        required
      >
        {categories &&
          categories.map((item, i) => {
            return (
              <MenuItem key={i} value={item.id}>
                {item.name}
              </MenuItem>
            );
          })}
      </TextField>
      <Typography>Description:</Typography>
      <TextField
        type="text"
        multiline
        fullWidth
        required
        value={input.description}
        onChange={(e) => setInput({ ...input, description: e.target.value })}
      />
      <Divider sx={{ mt: 1 }} />
      <Typography>Add ingredients</Typography>
      <TextField
        select
        fullWidth
        required
        label="Ingredient"
        onChange={ingredientChangeHandler}
      >
        {ingredients &&
          ingredients.map((item) => {
            return (
              <MenuItem key={item.id} value={item.id} name={item.name}>
                {item.name}
              </MenuItem>
            );
          })}
      </TextField>
      <TextField
        fullWidth
        required
        type="number"
        value={oneIng.quantity}
        onChange={(e) => setOneIng({ ...oneIng, quantity: e.target.value })}
      />
      <TextField label="Unit" select fullWidth onChange={onChangeIngUnit}>
        {units.map((item, i) => {
          return (
            <MenuItem key={i} value={item}>
              {item}
            </MenuItem>
          );
        })}
      </TextField>
      <Button onClick={addIngredientToArr} disabled={oneIng.unit === ""}>
        Add ingredient
      </Button>

      {input.recipeIngredients.length > 0 &&
        input.recipeIngredients.map((item, i) => {
          return (
            <Box key={item.ingredientId + i}>
              {item.ingredientId === 1 && <Typography>Oil</Typography>}
              {item.ingredientId === 2 && <Typography>Flour</Typography>}
              {item.ingredientId === 3 && <Typography>Sugar</Typography>}
              {item.ingredientId === 4 && <Typography>Salt</Typography>}
              {item.ingredientId === 5 && <Typography>Olive Oil</Typography>}
              {item.ingredientId === 6 && <Typography>Eggs</Typography>}
              {item.ingredientId === 7 && <Typography>Chicken meat</Typography>}
              {item.quantity + item.unit}
            </Box>
          );
        })}
      <Typography sx={{ color: "green" }}>{message}</Typography>
      {input.recipeIngredients.length > 0 && (
        <Button fullWidth variant="contained" type="submit">
          Create recipe
        </Button>
      )}
    </Box>
  );
};

export default AddRecipe;
