import React from "react";
import { Link, useHistory } from "react-router-dom";
import { Button, Container, Icon, Menu, Segment } from "semantic-ui-react";

const Navi = () => {
  return (
    <div>
      <Menu inverted size="large" className="app" color="black">
        <Container>
          <Menu.Item onClick={() => {}}>
            <Link to="/">Main Page</Link>
          </Menu.Item>
          <Menu.Item onClick={() => {}}>
            <Link to="/order">Orders</Link>
          </Menu.Item>

          <Menu.Item name="messages" position="right" onClick={() => {}}>
            <Link to="/cart">
              {" "}
              <Icon name="shopping cart" size="large" />
            </Link>
          </Menu.Item>
        </Container>
      </Menu>
    </div>
  );
};

export default Navi;
