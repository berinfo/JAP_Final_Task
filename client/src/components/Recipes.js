import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import axios from "axios";
import { Box, TextField, Typography } from "@mui/material";
import { japActions } from "../store";
import jwt_decode from "jwt-decode";

import ListComponent from "./ListComponent";

const style = {
  recipesContainer: {
    margin: "10% auto",
    textAlign: "center",
  },
  categoryHeading: {
    fontSize: "25px",
  },
  recipesHeading: {
    fontSize: "20px",
  },
  recipes: {},
};

const Recipes = () => {
  const [recipeView, setRecipeView] = useState(true);
  const [input, setInput] = useState("");
  const token = sessionStorage.getItem("token");

  // category id
  const { id } = useParams();

  const categoryName = useSelector((state) =>
    id ? state.states.categories.find((c) => c.id === +id) : null
  );

  const dispatch = useDispatch();

  useEffect(() => {
    getCategory(id);
    return () => setRecipeView(true);
    // eslint-disable-next-line
  }, []);
  // https://localhost:5001/Recipe/Search?categoryId=4&word=be

  async function getCategory(id) {
    await axios
      .get(`https://localhost:5001/Recipes/GetByCategory?categoryId=${id}`, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      })
      .then((res) => {
        dispatch(japActions.setRecipes(res.data.data));
      })
      .catch((err) => {
        console.log(err);
      });
  }
  async function searchRecipe(e) {
    setInput(e.target.value);
    if (input.length > 1) {
      await axios
        .get(
          `https://localhost:5001/Recipes/Search?categoryId=${id}&word=${input}`,
          {
            headers: {
              Authorization: `bearer ${token}`,
            },
          }
        )
        .then((res) => {
          dispatch(japActions.setRecipes(res.data.data));
        })
        .catch((err) => console.log(err));
    } else {
      getCategory(id);
    }
  }

  return (
    <Box sx={style.recipesContainer}>
      <TextField
        fullWidth
        type="text"
        value={input}
        onChange={searchRecipe}
        label="Search..."
      />
      <Typography>Category name:</Typography>
      <Typography sx={style.categoryHeading}>{categoryName?.name}</Typography>
      <Box sx={style.recipes}>
        <Typography sx={style.recipesHeading}>Recipes:</Typography>
        <ListComponent recipeView={recipeView} />
      </Box>
    </Box>
  );
};

export default Recipes;
