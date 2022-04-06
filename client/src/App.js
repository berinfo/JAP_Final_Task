import React from "react";
import { Routes, Route, BrowserRouter as Router } from "react-router-dom";
import { Box } from "@mui/material";

import Header from "./components/Header";
import Login from "./components/Login";
import Categories from "./components/Categories";
import Recipes from "./components/Recipes";
import Recipe from "./components/Recipe";
import AddRecipe from "./components/AddRecipe";
import PrivateRoute from "./components/Auth/PrivateRoute";
const style = {
  app: {
    minHeight: "100vh",
    overflow: "auto",
  },
};

function App() {
  return (
    <Box className="app" sx={style.app}>
      <Router>
        <Header />
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/categories" element={<Categories />} />
          <Route path="/recipes/:id" element={<Recipes />} />
          <Route
            path="/recipe/:id"
            element={
              <PrivateRoute>
                <Recipe />
              </PrivateRoute>
            }
          />
          <Route
            path="/addrecipe"
            element={
              <PrivateRoute>
                <AddRecipe />
              </PrivateRoute>
            }
          />
        </Routes>
      </Router>
    </Box>
  );
}

export default App;
