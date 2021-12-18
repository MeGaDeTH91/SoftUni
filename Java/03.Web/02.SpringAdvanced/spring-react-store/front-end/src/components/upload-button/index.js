import React from "react";
import styled from "styled-components";

const UploadButton = ({ id, label, value, onChange, title, click }) => {
  
  return (
    <FormControlDiv>
      <Label htmlFor={id}>{label}:</Label>
      <InputField type='text' name={id} id={id} onChange={onChange} value={value} />
      <UploadBtn type="button" id={id} onClick={click} >{title}</UploadBtn>
    </FormControlDiv>
  );
};

const InputField = styled.input`
  text-align: center;
  border: 1px solid #234465;
  padding: 1%;
  width: 50%;
  border-radius: 6px;
  color: #343a40;
`;

const FormControlDiv = styled.div`
  width: 30%;
  margin: 0 auto;
  padding: 1%;
  text-align: center;
`;

const UploadBtn = styled.button`
  background-color: #b87d17;
  color: white;
  padding: 2%;
  width: auto;
  border-radius: 6px;
  display: block;
  margin-top: 300px;
  margin-left: 190px;
  border: none;
  margin-top: 0.5%;
  border: 2px solid white;

  &:hover {
    background-color: #17a2b8;
    border: 1px #b817a1;
    color: #b82c17;
    font-style: italic;
  }
`;

const Label = styled.label`
  float: left;
  width: 30%;
  text-align: right;
`;

export default UploadButton;
