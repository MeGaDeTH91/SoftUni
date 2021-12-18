import React from "react";
import styled from "styled-components";

const CardBody = ({ title, price, quantity }) => {
  return (
    <Body>
      <h4>{ title.length > 21 ? (title) : (<div> {title}<br /><br /></div>)}</h4>
      <hr />
      <h3>{price}lv.</h3>
      <p>{quantity} pieces left.</p>
    </Body>
  );
};

const Body = styled.div`
  webkit-box-flex: 1;
  ms-flex: 1 1 auto;
  flex: 1 1 auto;
  padding: 1.25rem;
  word-wrap: break-word;
  box-sizing: border-box;
`;

export default CardBody;
