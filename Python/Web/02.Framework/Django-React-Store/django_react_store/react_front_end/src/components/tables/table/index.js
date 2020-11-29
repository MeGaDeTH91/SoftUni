import React from "react";
import styles from "./index.module.css";
import TableRow from "../row";
import styled from "styled-components";

const Table = ({ users }) => {
  return (
    <table className={styles.table}>
      <thead className={styles.head}>
        <tr className={styles.row}>
          <TH>#</TH>
          <TH>Username</TH>
          <TH>Email</TH>
          <TH>Full Name</TH>
          <TH>Address</TH>
          <TH>Active</TH>
          <TH>Administrator</TH>
          <TH>Actions</TH>
        </tr>
      </thead>
      <tbody className={styles.body}>
        {users.map((user, index) => {
          return <TableRow key={user.username} index={index} user={user} />;
        })}
      </tbody>
    </table>
  );
};

const TH = styled.th`
  color: #cc7f1b;
  border: 3px black;
`;

export default Table;
