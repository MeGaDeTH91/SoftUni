import React from "react";
import styled from "styled-components";

const EditButton = ({ title, onClick }) => {
  return (
    <Button onClick={onClick}>
      {title}
    </Button>
  );
};

const Button = styled.button`
  background-color: #ff9c0793 !important;
  color: black;
  padding: 2%;
  width: auto;
  border-radius: 6px;
  display: block;
  margin: 0 auto;
  border: none;
  margin-top: 5.5%;
  border: 2px solid white;
  margin-bottom: 2%;
  display: inline-block;

  &:hover {
    background-color: #17a2b8;
    border: 2px solid #234465;
    color: #b82c17;
    cursor: pointer;
    font-style: italic;
  }
`;

export default EditButton;
