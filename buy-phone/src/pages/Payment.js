import React, { useState } from "react";
import Cards from "react-credit-cards";

import { Button, Input, Form, Card, Message } from "semantic-ui-react";
import {
  formatCreditCardNumber,
  formatCVC,
  formatExpirationDate,
  formatFormData,
} from "../layout/Utils";
import axios, { BASE_URL } from "../api/axios";
import { Navigate } from "react-router-dom";
import swal from "sweetalert";
const initialState = {
  cardNumber: "",
  name: "",
  expiry: "",
  cvc: "",
  issuer: "",
  focused: "",
  formData: null,
};
export default class PaymentForm extends React.Component {
  state = {
    cardNumber: "",
    name: "",
    expiry: "",
    cvc: "",
    issuer: "",
    focused: "",
    formData: null,
    success: false,
  };

  handleCallback = ({ issuer }, isValid) => {
    if (isValid) {
      this.setState({ issuer });
    }
  };

  handleInputFocus = ({ target }) => {
    this.setState({
      focused: target.name,
    });
  };

  handleInputChange = ({ target }) => {
    if (target.name === "cardNumber") {
      target.value = formatCreditCardNumber(target.value);
    } else if (target.name === "expiry") {
      target.value = formatExpirationDate(target.value);
    } else if (target.name === "cvc") {
      target.value = formatCVC(target.value);
    }

    this.setState({ [target.name]: target.value });
  };

  handleSubmit = async (e) => {
    e.preventDefault();
    const { issuer } = this.state;
    const formData = [...e.target.elements]
      .filter((d) => d.name)
      .reduce((acc, d) => {
        acc[d.name] = d.value;
        return acc;
      }, {});

    try {
      let lastFourDigit = String(this.state.cardNumber).slice(-4);
      const response = await axios.post(`${BASE_URL}/payment`, formData);

      if (response?.data == "Success") {
        const response = await axios.get(`${BASE_URL}/getAll`);
        console.log(response.data);

        let orderObject = {
          items: ([] = response?.data?.items),
          creditCardInfo: lastFourDigit,
        };

        const orderResponse = await axios.post(
          `${BASE_URL}/createOrder`,
          orderObject
        );
        this.setState({ success: true });
        swal({
          title: "Success!",
          text: "Payment successful!",
          icon: "success",
          button: "Ok!",
        });
      } else {
        swal({
          title: "Error!",
          text: "Please enter your card information correctly!",
          icon: "error",
          button: "Ok!",
        });
      }
    } catch (error) {
      this.setState(initialState);
      swal({
        title: "Error!",
        text: "Please enter your card information correctly!",
        icon: "error",
        button: "Try again!",
      });
      let sendThru = () => {
        this.cardNumber.value = "";
        this.name.value = "";
        this.expiry.value = "";
        this.cvc.value = "";
      };
      console.log(error);
      //return error?.response?.data;
    }
    this.setState(initialState);
    console.log(formData);
    this.setState({ formData });
    this.form.reset();
  };

  render() {
    return (
      <div key="Payment">
        <div className="App-payment">
          <Cards
            cvc={this.state.cvc}
            expiry={this.state.expiry}
            focused={this.state.focus}
            name={this.state.name}
            number={this.state.cardNumber}
          />
          <Card.Group centered itemsPerRow={2}>
            <Form
              unstackable
              ref={(c) => (this.form = c)}
              onSubmit={this.handleSubmit}
            >
              <Form.Group>
                <Form.Input
                  value={this.state.cardNumber}
                  type="tel"
                  name="cardNumber"
                  className="form-control"
                  placeholder="Card Number"
                  pattern="[\d| ]{16,22}"
                  required
                  onChange={this.handleInputChange}
                  onFocus={this.handleInputFocus}
                />

                <Form.Input
                  value={this.state.name}
                  type="text"
                  name="name"
                  className="form-control"
                  placeholder="Name"
                  required
                  onChange={this.handleInputChange}
                  onFocus={this.handleInputFocus}
                />
              </Form.Group>

              <Form.Group>
                <Form.Input
                  value={this.state.expiry}
                  type="tel"
                  name="expiry"
                  className="form-control"
                  placeholder="Valid Thru"
                  pattern="\d\d/\d\d"
                  required
                  onChange={this.handleInputChange}
                  onFocus={this.handleInputFocus}
                />
                <Form.Input
                  value={this.state.cvc}
                  type="tel"
                  name="cvc"
                  className="form-control"
                  placeholder="CVC"
                  pattern="\d{3,4}"
                  required
                  onChange={this.handleInputChange}
                  onFocus={this.handleInputFocus}
                />
              </Form.Group>

              <div className="form-actions">
                <Button className="btn btn-primary btn-block">PAY</Button>
              </div>
            </Form>
            {this.state.success && <Navigate to="/order" replace={true} />}
          </Card.Group>
        </div>
      </div>
    );
  }
}
