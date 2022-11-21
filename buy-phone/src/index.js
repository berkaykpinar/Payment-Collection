import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App.js";
import reportWebVitals from "./reportWebVitals";
import ProductList from "./pages/ProductList";
import Navi from "./layout/Navi";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "semantic-ui-css/semantic.min.css";
import "react-credit-cards/es/styles-compiled.css";
ReactDOM.render(
  <BrowserRouter>
    <React.StrictMode>
      <Routes>
        <Route path="/*" element={<App />} />
      </Routes>
    </React.StrictMode>
  </BrowserRouter>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
