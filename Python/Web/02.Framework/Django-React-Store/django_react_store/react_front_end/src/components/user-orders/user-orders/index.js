import React from "react";
import styles from "./index.module.css";
import orderLogo from "../../../images/orders.png";
import TextLink from "../../text-link";

const UserOrder = ( { order, index } ) => {

  const formattedDate = order.created_at.slice(0, 10);

  return (
    <div className={styles.container}>
      <img
        src={orderLogo}
        className={styles["order-image"]}
        alt="order"
      ></img>
      <p className={styles.description}>{`${index + 1} - #Order: ${order.id}`}</p>
      <div>
        <span className={styles.user}>
          <small>Products: </small>
          
        </span>
        {order.products ? 
        (order.products
          .map((product, currentIndex) => <TextLink key={product.id} title={product.title} href={`products/product-details/${product.id}`} />)
          .reduce((prev, curr) => [prev, ', ', curr]))
        : (<p>Database error.</p>)}
      </div>
      <div>
        <span className={styles.user}>
          <small>Made: </small>
          {formattedDate}
        </span>
      </div>
    </div>
  );
};

export default UserOrder;
