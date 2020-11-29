import React from "react";
import TextLink from "../../text-link";
import styled from "styled-components";

const CardParagraph = ({ title, id }) => {
  return (
    <Paragraph>
      <TextLink
        title={`Category: ${title}`}
        href={`/categories/category/${id}`}
      ></TextLink>
    </Paragraph>
  );
};

const Paragraph = styled.p`
  text-align: center;
  color: black;
  margin-bottom: 0;
  margin-top: 0;
  box-sizing: border-box;
`;

export default CardParagraph;
