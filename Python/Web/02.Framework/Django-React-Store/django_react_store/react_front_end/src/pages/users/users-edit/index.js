import React, { useContext, useState, useCallback, useEffect } from "react";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import Input from "../../../components/input/active";
import { useHistory } from "react-router-dom";
import NotificationContext from "../../../NotificationContext";
import DisabledInput from "../../../components/input/disabled";
import SubmitButton from "../../../components/buttons/submit";
import executeAuthGetRequest from "../../../utils/executeAuthGETRequest";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import UserContext from "../../../UserContext";
import validateTextField from "../../../utils/validateField";

const EditUserPage = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [first_name, setFirstName] = useState("");
  const [last_name, setLastName] = useState("");
  const [address, setAddress] = useState("");

  const notifications = useContext(NotificationContext);
  const userContext = useContext(UserContext);
  const history = useHistory();

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!validateTextField(first_name, "Please provide first name.", notifications) || 
    !validateTextField(last_name, "Please provide last name.", notifications) ||
    !validateTextField(email, "Please provide valid email address.", notifications) ||
    !validateTextField(address, "Please provide valid delivery address.", notifications)) {
      return;
    }

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/profile-edit/${userContext.user.id}/`,
      "PUT",
      {
        email,
        first_name,
        last_name,
        address
      },
      (user) => {
        notifications.showMessage("User information updated successfully!", "success");
      },
      (error) => {
        notifications.showMessage(
          error,
          "danger"
        );
        
      }
    );
    history.push(`/profile-details`);
  };

  const getUser = useCallback(async () => {
    await executeAuthGetRequest(
      `http://127.0.0.1:8000/api/profile-edit/${userContext.user.id}/`,
      (user) => {
        setUsername(user.username);
        setEmail(user.email);
        setFirstName(user.first_name);
        setLastName(user.last_name);
        setAddress(user.address);
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push("/");
      }
    );
  }, [history, notifications, userContext.user]);

  useEffect(() => {
    getUser();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const goBack = (e) => {
    e.preventDefault();

    history.goBack();
  };

  return (
    <PageLayout>
      <RegisterForm onSubmit={handleSubmit}>
        <Title title="Update user info" />
        <hr />
        <DisabledInput id="username" value={username || ''} label="Username"></DisabledInput>
        <Input id="email" value={email || ''} label="Email" onChange={(e) => setEmail(e.target.value)}></Input>
        <Input
          id="first_name"
          value={first_name  || ''}
          label="First Name"
          onChange={(e) => setFirstName(e.target.value)}
        ></Input>
        <Input
          id="last_name"
          value={last_name  || ''}
          label="Last Name"
          onChange={(e) => setLastName(e.target.value)}
        ></Input>
        <Input
          id="address"
          value={address  || ''}
          label="Address"
          onChange={(e) => setAddress(e.target.value)}
        ></Input>
        <SubmitButton title="Update info" goBack={goBack} />
      </RegisterForm>
    </PageLayout>
  );
};

const RegisterForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default EditUserPage;
