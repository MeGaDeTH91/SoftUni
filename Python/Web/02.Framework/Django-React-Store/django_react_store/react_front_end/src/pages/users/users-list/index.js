import React, { useContext, useState, useEffect } from "react";
import PageLayout from "../../../components/page-layout";
import NotificationContext from "../../../NotificationContext";
import { useHistory } from "react-router-dom";
import executeAuthGetRequest from "../../../utils/executeAuthGETRequest";
import Table from "../../../components/tables/table";
import usersImage from "../../../images/user.jpg";

const UsersPage = () => {
  const notifications = useContext(NotificationContext);
  const history = useHistory();

  const [users, setUsers] = useState([]);

  const getUsers = async () => {
    await executeAuthGetRequest(
      `http://127.0.0.1:8000/api/users/all`,
      (usersResponse) => {
        setUsers(usersResponse);
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push("/users");
      }
    );
  };

  useEffect(() => {
    getUsers();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  if (!users) {
    return <PageLayout>Loading...</PageLayout>;
  }

  return (
    <PageLayout>
      <h1 className="my-4">Users management</h1>
      <h4 className="my-3">Manage user roles and bans</h4>

      <img className="img-fluid" src={usersImage} alt="Express" />
      <div className="container">
        <h4 className="text-center">Users</h4>
        {users && users.length ? (
          <Table users={users} />
        ) : (
          <p>No users in database.</p>
        )}
      </div>
    </PageLayout>
  );
};

export default UsersPage;
