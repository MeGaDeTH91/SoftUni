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
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [address, setAddress] = useState("");

  const notifications = useContext(NotificationContext);
  const userContext = useContext(UserContext);
  const history = useHistory();

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!validateTextField(firstName, "Please provide first name.", notifications) ||
    !validateTextField(lastName, "Please provide last name.", notifications) ||
    !validateTextField(email, "Please provide valid email address.", notifications)) {
      return;
    }

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/users/${userContext.user.id}`,
      "PUT",
      {
        email,
        firstName,
        lastName,
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
      `http://127.0.0.1:8000/api/users/${userContext.user.id}`,
      (user) => {
        setUsername(user.username);
        setEmail(user.email);
        setFirstName(user.firstName);
        setLastName(user.lastName);
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
        <DisabledInput id="username" value={username || ''} label="Username" />
        <Input id="email" value={email || ''} label="Email" onChange={(e) => setEmail(e.target.value)} />
        <Input
          id="first_name"
          value={firstName  || ''}
          label="First Name"
          onChange={(e) => setFirstName(e.target.value)}
        />
        <Input
          id="last_name"
          value={lastName  || ''}
          label="Last Name"
          onChange={(e) => setLastName(e.target.value)}
        />
        <Input
          id="address"
          value={address  || ''}
          label="Address"
          onChange={(e) => setAddress(e.target.value)}
        />
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
