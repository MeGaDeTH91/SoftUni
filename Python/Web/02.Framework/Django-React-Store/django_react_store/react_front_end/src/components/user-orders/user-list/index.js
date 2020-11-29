import React from "react";
import styles from "./index.module.css";
import UserOrder from "../user-orders";

const ListUserOrders = ( { orders } ) => {

  const renderOrders = () => {

    return orders.map((order, index) => {
      return <UserOrder key={order.id} index={index} order={order} />;
    });
  };

  return <div className={styles["orders-wrapper"]}>{renderOrders()}</div>;
};

export default ListUserOrders;
