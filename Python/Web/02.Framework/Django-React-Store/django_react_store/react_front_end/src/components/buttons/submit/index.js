import React from "react";
import styled from "styled-components";
import GoBackButton from "../back";

const SubmitButton = ({ title, goBack }) => {
  return (
    <div>
      <FormControlDiv>
        <span>
          <FormButton type="submit">{title}</FormButton>
          <GoBackButton onClick={goBack} />
        </span>
      </FormControlDiv>
      
    </div>
  );
};

const FormControlDiv = styled.div`
  width: 30%;
  margin: 0 auto;
  padding: 1%;
  text-align: center;
`;

const FormButton = styled.button`
  background-color: #343a40;
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

export default SubmitButton;
