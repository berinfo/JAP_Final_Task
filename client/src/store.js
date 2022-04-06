import { createSlice, configureStore } from "@reduxjs/toolkit";

const japSlice = createSlice({
  name: "states",
  initialState: {
    user: false,
    recipes: [],
    ingredients: [],
    categories: [],
    recipe: {},
  },
  reducers: {
    setCategories(state, { payload }) {
      state.categories = payload;
    },
    setRecipes(state, { payload }) {
      state.recipes = payload;
    },
    setIngredients(state, { payload }) {
      state.ingredients = payload;
    },
    setRecipe(state, { payload }) {
      state.recipe = payload;
    },
  },
});

export const store = configureStore({
  reducer: {
    states: japSlice.reducer,
  },
});
export const japActions = japSlice.actions;
