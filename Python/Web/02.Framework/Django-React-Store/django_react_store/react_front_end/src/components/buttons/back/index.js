import React from "react";
import styled from "styled-components";

const GoBackButton = ({ onClick }) => {
  return <BackButton onClick={onClick}>{"Go Back"}</BackButton>;
};

const BackButton = styled.button`
  background-color: #e1e2e2;
  color: #b817a1;
  padding: 2%;
  width: auto;
  border-radius: 6px;
  display: inline-block;
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

export default GoBackButton;
