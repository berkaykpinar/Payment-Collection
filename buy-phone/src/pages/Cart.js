import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
  Header,
  Table,
  Rating,
  Grid,
  GridColumn,
  Menu,
  Label,
  Input,
  Icon,
  Button,
  Card,
} from "semantic-ui-react";
import axios, { BASE_URL } from "../api/axios";
import swal from "sweetalert";
const Cart = () => {
  const [itemList, setItemList] = useState([]);
  const [refresh, setRefresh] = useState(true);
  const [total, setTotal] = useState(0);
  useEffect(async () => {
    try {
      const response = await axios.get(`${BASE_URL}/getAll`);
      setItemList(response?.data?.items);

      setTotal(response?.data?.total);
      console.log(response);
    } catch (error) {
      console.log(error);
    }
  }, [refresh]);

  let AddItem = async (id) => {
    try {
      const response = await axios.post(`${BASE_URL}/item/addtocart?id=` + id);
      swal("Item has been added to your cart!");
      setRefresh(false);
      setRefresh(true);
      console.log(response);
    } catch (error) {
      console.log(error);
    }
  };

  let RemoveItem = async (id) => {
    try {
      const response = await axios.post(`${BASE_URL}/remove?id=` + id);
      swal("Item has been removed from your cart!");
      setRefresh(false);
      console.log(response);
      setRefresh(true);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div>
      <Grid>
        <GridColumn width={12}>
          <Table celled padded>
            <Table.Header>
              <Table.Row>
                <Table.HeaderCell singleLine>Details</Table.HeaderCell>
                <Table.HeaderCell>Name</Table.HeaderCell>
                <Table.HeaderCell>Price</Table.HeaderCell>
                <Table.HeaderCell>Quantity</Table.HeaderCell>
                <Table.HeaderCell>Subtotal</Table.HeaderCell>
                <Table.HeaderCell>Add Item</Table.HeaderCell>
                <Table.HeaderCell>Remove Item</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {itemList.map((list, index) => (
                <Table.Row style={{ marginTop: "10px" }} key={index}>
                  <Table.Cell>
                    <Link to={`/item/${list.id}`}>
                      {" "}
                      <Icon size="large" name="zoom"></Icon>
                    </Link>
                  </Table.Cell>
                  <Table.Cell>{list.name}</Table.Cell>
                  <Table.Cell>{list.price} $</Table.Cell>
                  <Table.Cell>{list.inCart} </Table.Cell>
                  <Table.Cell>{list.inCart * list.price} $</Table.Cell>

                  <Table.Cell>
                    <Button
                      color="green"
                      onClick={() => {
                        AddItem(list.id);
                      }}
                    >
                      <Icon fitted name="plus" />
                    </Button>
                  </Table.Cell>
                  <Table.Cell>
                    <Button
                      color="red"
                      onClick={() => {
                        RemoveItem(list.id);
                      }}
                    >
                      <Icon fitted name="minus" />
                    </Button>
                  </Table.Cell>
                </Table.Row>
              ))}
            </Table.Body>
          </Table>
        </GridColumn>
        <GridColumn width={4}>
          {" "}
          <Card>
            <Card.Content>
              <h2>Total : {total} $</h2>
            </Card.Content>

            <Card.Content>
              <Link to={"/payment"}>
                <Button color="blue" onClick={() => {}}>
                  Go to Payment <Icon name="arrow right" />
                </Button>
              </Link>
            </Card.Content>
          </Card>
        </GridColumn>
      </Grid>
    </div>
  );
};

export default Cart;
