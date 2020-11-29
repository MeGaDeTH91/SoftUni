import React from 'react';
import styled from "styled-components";

const CardDeckComponent = (props) => {
    return (
        <Container>
            <Row>
              <CardDeck>
                {props.children}
              </CardDeck>
            </Row>
          </Container>
    )
}


const Container = styled.div`
margin: auto;
width: 100%;
padding: 10px;
`;

const Row = styled.div`
  webkit-box-pack: center !important;
  justify-content: center !important;
  flex-wrap: wrap;
  margin-right: 15px;
  margin-left: 115px;
  display: flex !important;
  box-sizing: border-box;
`;

const CardDeck = styled.div`
  flex-flow: row wrap;
  margin-right: -15px;
  margin-left: -15px;
  display: flex;
  box-sizing: border-box;
`;

export default CardDeckComponent;