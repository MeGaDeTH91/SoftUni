import React from "react";
import styled from "styled-components";
import EditButton from "../../buttons/edit";
import DeleteButton from "../../buttons/delete";

const CardFooter = ({ title, editProduct, deleteProduct }) => {
  return (
    <Footer>
      <EditButton title={`Edit ${title}`} onClick={editProduct}></EditButton>
      <DeleteButton
        title={`Delete ${title}`}
        onClick={deleteProduct}
      ></DeleteButton>
    </Footer>
  );
};

const Footer = styled.div`
  border-radius: 0 0 calc(0.25rem - 1px) calc(0.25rem - 1px);
  background-color: #dddddd;
  color: white;
  border-top: 1px solid #dddddd;
  margin: 0;
  padding: 0;
  font-size: medium;
  font-family: "Miltonian Tattoo", cursive;
`;

export default CardFooter;
