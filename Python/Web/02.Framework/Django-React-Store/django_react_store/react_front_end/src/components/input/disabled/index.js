import React from "react";
import styled from "styled-components";

const DisabledInput = ({ id, label, type, value }) => {
  
  return (
    <FormControlDiv>
      <Label htmlFor={id}>{label}:</Label>
      <InputField type={type || 'text'} disabled name={id} id={id} value={value} />
    </FormControlDiv>
  );
};

const FormControlDiv = styled.div`
  width: 30%;
  margin: 0 auto;
  padding: 1%;
  text-align: center;
`;

const InputField = styled.input`
  text-align: center;
  border: 1px solid #234465;
  padding: 1%;
  width: 50%;
  border-radius: 6px;
  color: #343a40;
`;

const Label = styled.label`
  float: left;
  width: 30%;
  text-align: right;
`;

export default DisabledInput;
