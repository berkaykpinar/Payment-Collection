import { Alert } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import {
  Grid,
  Image,
  Card,
  Icon,
  Menu,
  Label,
  Segment,
  Header,
  Button,
} from "semantic-ui-react";
import axios, { BASE_URL } from "../api/axios";
const ProductDetails = () => {
  let { itemId } = useParams();
  let navigate = useNavigate();
  const [itemDetails, setItemDetails] = useState([]);
  const [contactInfo, setContactInfo] = useState([]);

  useEffect(async () => {
    try {
      const response = await axios.get(`${BASE_URL}/item/getItem/${itemId}`);
      setItemDetails(response?.data);
      //console.log(response);
    } catch (error) {
      console.log(error);
      return error?.response?.data;
      //giriş yaptıktan sonra gitmek istediğimiz sayfaya geri döneriz
      //navigate("/login", { state: { from: location }, replace: true });
    }
  }, []);

  let HandleAddToCartButton = async () => {
    try {
      const response = await axios.post(
        `${BASE_URL}/item/addtocart?id=` + itemId
      );
      //alert("Item has added your cart!");
      navigate("/cart");
      console.log("!added");
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div>
      <Grid>
        <Grid.Column width={4}>
          <Menu vertical>
            <Menu.Item>
              {" "}
              <Header as="h3">Buy Right Now {itemId}</Header>
            </Menu.Item>
            {/* <Menu.Item name="inbox">
              <Label color="teal">{`${itemDetails?.name}`}</Label>
            </Menu.Item> */}

            <Menu.Item name="inbox">
              <Label color="teal">{`${itemDetails?.price} $`}</Label>
              Price
            </Menu.Item>
            <Menu.Item name="inbox">
              <Label color="red">{`${itemDetails?.quantity} `}</Label>
              Stock
            </Menu.Item>
          </Menu>
        </Grid.Column>
        <Grid.Column width={8}>
          <Segment.Group>
            <Segment>
              <h2>{`${itemDetails?.name}`}</h2>
            </Segment>
            <Segment>
              <p>{`${itemDetails?.description}`}</p>
            </Segment>
          </Segment.Group>
        </Grid.Column>
        <Grid.Column width={4}>
          <Card>
            <Card.Content header="Add To cart" />

            <Card.Content>
              <Button
                color="green"
                onClick={() => {
                  HandleAddToCartButton();
                }}
              >
                Add to Cart <Icon name="arrow right" />
              </Button>
            </Card.Content>
          </Card>
        </Grid.Column>
      </Grid>
    </div>
  );
};

export default ProductDetails;
