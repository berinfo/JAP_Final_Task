import axios from "axios";

const token = sessionStorage.getItem("token");
const url = "https://localhost:5001/";

function getCategories() {
  axios.get(`${url} + Category/GetAll`, {
    headers: {
      Authorization: `bearer ${token}`,
    },
  });
}
export { getCategories };
