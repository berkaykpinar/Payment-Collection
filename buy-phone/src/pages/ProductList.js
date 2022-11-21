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
} from "semantic-ui-react";
//import MemberService from "../api/MemberService";
import axios, { BASE_URL } from "../api/axios";
const ProductList = () => {
  const [itemList, setItemList] = useState([]);

  useEffect(async () => {
    try {
      const response = await axios.get(`${BASE_URL}/item/getallItems`);
      setItemList(response?.data);
      console.log(response);
    } catch (error) {
      console.log(error);
    }
  }, []);

  return (
    <div>
      <Grid>
        <GridColumn width={4}>
          <Menu pointing vertical>
            <Menu.Item name="inbox">
              <Label color="teal">{`${itemList.length}`}</Label>
              Product Number
            </Menu.Item>
          </Menu>
        </GridColumn>
        <GridColumn width={12}>
          <Table celled padded>
            <Table.Header>
              <Table.Row>
                <Table.HeaderCell singleLine>Details</Table.HeaderCell>
                <Table.HeaderCell>Name</Table.HeaderCell>

                <Table.HeaderCell>Price</Table.HeaderCell>
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
                  <Table.Cell>{list.price}</Table.Cell>
                </Table.Row>
              ))}
            </Table.Body>
          </Table>
        </GridColumn>
      </Grid>
    </div>
  );
};

export default ProductList;
