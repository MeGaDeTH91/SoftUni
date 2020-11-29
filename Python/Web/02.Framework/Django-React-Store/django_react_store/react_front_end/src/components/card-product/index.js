import React, { useContext } from "react";
import { useHistory } from "react-router-dom";
import styled from "styled-components";
import styles from "./index.module.css";
import UserContext from "../../UserContext";
import CardBody from "../card-basics/body";
import CardFooter from "../card-basics/footer";
import CardParagraph from "../card-basics/paragraph";

const CardProduct = (props) => {
  const { productId, imageURL, title, price, category, quantity } = props;
  const history = useHistory();
  const context = useContext(UserContext);

  const onDetails = () => {
    history.push(`/products/product-details/${productId}`);
  };

  const { user } = context;
  const userIsAdministrator = user && user.is_superuser;

  const editProduct = () => {
    history.push(`/products/product-edit/${productId}`);
  };

  const deleteProduct = () => {
    history.push(`/products/product-delete/${productId}`);
  };

  return (
    <Card>
      <div className={styles.thumbnail} onClick={onDetails}>
        <CardImage src={imageURL} alt="Card image cap"></CardImage>
        <CardBody title={title} price={price} quantity={quantity} />
      </div>
      <br />
      <CardParagraph title={category.title} id={category.id} />
      <hr />
      {userIsAdministrator ? (
        <CardFooter
          title="product"
          editProduct={editProduct}
          deleteProduct={deleteProduct}
        />
      ) : null}
    </Card>
  );
};

const Card = styled.div`
  box-sizing: border-box;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
  position: relative;
  min-width: 18rem;
  max-width: 18rem;
  margin-bottom: 1.5rem !important;
  display: flex;
  flex: 1 0 0%;
  flex-direction: column;
  margin-right: 15px;
  margin-bottom: 0;
  margin-left: 50px;
`;

const CardImage = styled.img`
  width: 100%;
  height: 210px;
  object-fit: cover;
  border-top-left-radius: calc(0.25rem - 1px);
  border-top-right-radius: calc(0.25rem - 1px);
  border-style: none;
  box-sizing: border-box;
`;

export default CardProduct;
