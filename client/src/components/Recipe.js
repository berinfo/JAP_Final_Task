import React, { useState, useEffect } from "react";
import { Box, Typography, Divider } from "@mui/material";
import axios from "axios";
import { useSelector, useDispatch } from "react-redux";
import { japActions } from "../store";
import { useParams } from "react-router-dom";

import ListComponent from "./ListComponent";

const style = {
  recipe: {
    margin: "auto",
    textAlign: "center",
    maxWidth: "500px",
  },
  recipeHeading: {
    fontSize: "25px",
  },
};

const Recipe = () => {
  const [recipeView, setRecipeView] = useState(false);
  const { id } = useParams();
  const token = sessionStorage.getItem("token");
  const dispatch = useDispatch();
  const recipe = useSelector((state) => state.states.recipe);

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
        dispatch(japActions.setRecipe(res.data.data));
      })
      .catch((err) => {
        console.log(err);
      });
  };
  if (!recipe) return null;
  return (
    <Box sx={style.recipe}>
      <Typography>Recipe name:</Typography>
      <Typography sx={style.recipeHeading}>{recipe?.name}</Typography>
      <Divider></Divider>
      <Box>
        <Typography>Description:</Typography>
        <Typography sx={style.recipeHeading}>{recipe?.description}</Typography>
        <Divider></Divider>
      </Box>
      <Box sx={{ marginBottom: "20px" }}>
        <Typography>Ingredients:</Typography>
        {recipe.recipeIngredients &&
          recipe.recipeIngredients.map((item, i) => {
            return (
              <Typography key={item.quantity + i}>
                {item.ingredient.name} {item.quantity} {item.unit} $
              </Typography>
            );
          })}

        {/* <ListComponent recipeView={recipeView} /> */}
      </Box>
      <Typography sx={style.recipeHeading}>Total:{recipe?.price}$</Typography>
    </Box>
  );
};

export default Recipe;
