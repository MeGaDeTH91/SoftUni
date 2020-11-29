import React from "react";
import styled from "styled-components";

const TextAreaDisabled = ({ id, label, value, onChange }) => {
  return (
    <FormControlDiv>
      <Label htmlFor={id}>{label}:</Label>
      <TextAreaContainer value={value} name={id} disabled onChange={onChange}></TextAreaContainer>
    </FormControlDiv>
  );
};

const FormControlDiv = styled.div`
  width: 30%;
  margin: 0 auto;
  padding: 1%;
  text-align: center;
`;

const TextAreaContainer = styled.textarea`
  width: 60%;
  display: block;
  margin-left: auto;
  margin-right: auto;
  resize: none;
  padding: 2%;
  height: 11vh;
  font-style: italic;
  border-radius: 6px;
  border: 1px solid #234465;
  color: #343a40;
`;

const Label = styled.label`
  float: left;
  width: 30%;
  text-align: right;
`;

export default TextAreaDisabled;
