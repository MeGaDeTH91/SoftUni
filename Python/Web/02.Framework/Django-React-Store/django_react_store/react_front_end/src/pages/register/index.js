import React, { useContext, useState } from "react";
import styled from "styled-components";
import PageLayout from "../../components/page-layout";
import Title from "../../components/title";
import Input from "../../components/input/active";
import authenticate from "../../utils/authenticate";
import UserContext from "../../UserContext";
import { useHistory } from "react-router-dom";
import NotificationContext from "../../NotificationContext";

const RegisterPage = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [first_name, setFirstName] = useState("");
  const [last_name, setLastName] = useState("");
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [rePassword, setRePassword] = useState("");

  const context = useContext(UserContext);
  const notifications = useContext(NotificationContext);
  const history = useHistory();

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!username || !first_name || !last_name || !password || !rePassword || password.length < 3 || rePassword.length < 3) {
      notifications.showMessage('Username, full name, password and confirmation password should be more than 2 characters.', 'danger');
      return;
    }

    if (password !== rePassword) {
      notifications.showMessage('Passwords do not match.', 'danger');
      return;
    }

    const promise = await fetch("http://127.0.0.1:8000/api/users/register/", {
      method: "POST",
      body: JSON.stringify({
        username,
        email,
        first_name,
        last_name,
        address,
        password,
        rePassword
      }),
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!promise.ok) {
      notifications.showMessage('Please fill in all fields correctly.', 'danger');
      return;
    }

    await authenticate(
      "http://127.0.0.1:8000/api/users/login/",
      {
        username,
        password,
      },
      (user) => {
        console.log("Logged in successfully!");

        context.logIn(user);
        notifications.showMessage("Logged in successfully!", 'success');
        history.push("/");
      },
      (error) => {
        notifications.showMessage("Invalid credentials!", 'danger');
        history.push("/login");
      }
    );
  };

  return (
    <PageLayout>
      <RegisterForm onSubmit={handleSubmit}>
        <Title title="Register page" />
        <hr />
        <Input
          id="username"
          value={username}
          label="Username"
          onChange={(e) => setUsername(e.target.value)}
        ></Input>
        <Input
          id="email"
          value={email}
          label="Email"
          onChange={(e) => setEmail(e.target.value)}
        ></Input>
        <Input
          id="first_name"
          value={first_name}
          label="First name"
          onChange={(e) => setFirstName(e.target.value)}
        ></Input>
        <Input
          id="last_name"
          value={last_name}
          label="Last name"
          onChange={(e) => setLastName(e.target.value)}
        ></Input>
        <Input
          id="address"
          value={address}
          label="Address"
          onChange={(e) => setAddress(e.target.value)}
        ></Input>
        <Input
          type="password"
          id="password"
          value={password}
          label="Password"
          onChange={(e) => setPassword(e.target.value)}
        ></Input>
        <Input
          type="password"
          id="re-password"
          value={rePassword}
          label="Re-Password"
          onChange={(e) => setRePassword(e.target.value)}
        ></Input>
        <FormControlDiv>
          <FormButton type="submit">{"Register"}</FormButton>
        </FormControlDiv>
      </RegisterForm>
    </PageLayout>
  );
};

const RegisterForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;
const FormButton = styled.button`
  background-color: #343a40;
  color: #b817a1;
  padding: 2%;
  width: auto;
  border-radius: 6px;
  display: block;
  margin: 0 auto;
  border: none;
  margin-top: 0.5%;
  border: 2px solid white;
  margin-bottom: 2%;

  &:hover {
    background-color: #17a2b8;
    border: 2px solid #234465;
    color: #b82c17;
    font-style: italic;
  }
`;

const FormControlDiv = styled.div`
  width: 30%;
  margin: 0 auto;
  padding: 1%;
  text-align: center;
`;

export default RegisterPage;
