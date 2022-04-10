import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { japActions } from "../../store";
import axios from "axios";
import jwt_decode from "jwt-decode";
import { Box, Typography } from "@mui/material";

import ListComponent from "../ListComponent";

const style = {
  heading: { textAlign: "center", fontSize: "25px" },
};

const Categories = () => {
  const categories = useSelector((state) => state.states.categories);
  const dispatch = useDispatch();
  const [take, setTake] = useState(5);
  const token = sessionStorage.getItem("token");
  var decodedToken;
  if (token) {
    decodedToken = jwt_decode(token);
  }

  if (decodedToken) dispatch(japActions.setAdmin(decodedToken.role));

  useEffect(() => {
    async function getCategories() {
      await axios
        .get(`https://localhost:5001/Categories?n=${take}`)
        .then((res) => {
          dispatch(japActions.setCategories(res.data.data));
        })
        .catch((err) => {
          console.log(err);
        });
    }
    getCategories();
    // eslint-disable-next-line
  }, [take]);

  function onTake() {
    setTake((take) => take + 5);
  }
  return (
    <Box>
      <Typography sx={style.heading}>Latest categories:</Typography>
      <ListComponent categories={categories} onTake={onTake} take={take} />
    </Box>
  );
};

export default Categories;
