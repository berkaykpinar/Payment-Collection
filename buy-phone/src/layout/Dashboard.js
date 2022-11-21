import Order from "../pages/Order";
import PaymentForm from "../pages/Payment";
import ProductDetails from "../pages/ProductDetails";
import ProductList from "../pages/ProductList";
import { Routes, Route } from "react-router-dom";
import { Grid, GridColumn } from "semantic-ui-react";
import Cart from "../pages/Cart";
const Dashboard = () => {
  return (
    <div>
      <Grid>
        <Grid.Row>
          <GridColumn>
            <Routes>
              <Route exact path="/order" element={<Order />} />

              <Route exact path="/payment" element={<PaymentForm />} />
              <Route exact path="/" element={<ProductList />} />

              <Route exact path="/item/:itemId" element={<ProductDetails />} />

              <Route exact path="/cart" element={<Cart />} />
            </Routes>
          </GridColumn>
        </Grid.Row>
      </Grid>
    </div>
  );
};

export default Dashboard;
