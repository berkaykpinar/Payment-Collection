import logo from "./logo.svg";
import "./App.css";
import Navi from "./layout/Navi";
import ProductList from "./pages/ProductList";
import ProductDetails from "./pages/ProductDetails";
import Order from "./pages/Order";
import PaymentForm from "./pages/Payment";
import { Container } from "semantic-ui-react";
import Dashboard from "./layout/Dashboard";

function App() {
  return (
    <div className="App">
      <Navi />
      <Container className="main">
        <Dashboard />
      </Container>
    </div>
  );
}

export default App;
