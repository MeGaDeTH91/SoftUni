import React from "react";
import styles from "./index.module.css";
import styled from "styled-components";
import ShoppingCartTableRow from "../shopping-cart-row";
import formatPrice from "../../../utils/priceFormatter";

const ShoppingCartTable = ({ products }) => {
  let total = 0;

  return (
    <table className={styles.table}>
      <thead className={styles.head}>
        <tr className={styles.row}>
          <TH>#</TH>
          <TH>Product</TH>
          <TH>Actions</TH>
          <TH>Price</TH>
        </tr>
      </thead>
      <tbody className={styles.body}>
        {products.map((product, index) => {
          total += product.price;
          return <ShoppingCartTableRow key={index} index={index} product={product} />;
        })}
        <tr>
        <TD />
        <TD />
        <TD />
        <TD><h3>Total price: <i>{formatPrice(total)}lv</i></h3></TD>
        </tr>
      </tbody>
    </table>
  );
};

const TD = styled.td`
  color: black;
  border: 3px black;
`;

const TH = styled.th`
  color: #cc7f1b;
  border: 3px black;
`;

export default ShoppingCartTable;
