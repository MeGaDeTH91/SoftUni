import React from "react";
import styled from "styled-components";

const Title = ({ title }) => {
  return (
    <div>
      <br />
      <TitleStyle>{title}</TitleStyle>
    </div>
  );
};

const TitleStyle = styled.h1`
  text-align: center;
  color: #17a2b8;
  text-decoration: underline;
  margin-bottom: 2%;
`;

export default Title;
