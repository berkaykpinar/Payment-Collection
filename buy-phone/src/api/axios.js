import axios from "axios";
export const BASE_URL = "https://localhost:7127";
export default axios.create({
  baseURL: BASE_URL,
});