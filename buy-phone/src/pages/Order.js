import { useEffect, useState } from "react";
import { Table, Icon, Button } from "semantic-ui-react";
import axios, { BASE_URL } from "../api/axios";
const Order = () => {
  const [orderList, setOrderList] = useState([]);

  useEffect(async () => {
    try {
      const response = await axios.get(`${BASE_URL}/order`);
      setOrderList(response?.data);
      console.log(orderList);
    } catch (error) {
      console.log(error);
      //return err?.response?.data;
      //giriş yaptıktan sonra gitmek istediğimiz sayfaya geri döneriz
      //navigate("/login", { state: { from: location }, replace: true });
    }
  }, []);

  return (
    <div>
      <Table celled padded>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Date</Table.HeaderCell>
            <Table.HeaderCell>Total amount before tax</Table.HeaderCell>
            <Table.HeaderCell>Tax Rate</Table.HeaderCell>
            <Table.HeaderCell>Total</Table.HeaderCell>
            <Table.HeaderCell>Last 4 digit of credit card</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {orderList?.map((list, index) => (
            <Table.Row style={{ marginTop: "10px" }} key={index}>
              <Table.Cell>{list.dateCreated}</Table.Cell>
              <Table.Cell>{list.totalAmount}</Table.Cell>
              <Table.Cell>{list.tax}</Table.Cell>
              <Table.Cell>{list.taxIncAmount}</Table.Cell>
              <Table.Cell>{list.creditCardInfo}</Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </div>
  );
};

export default Order;
