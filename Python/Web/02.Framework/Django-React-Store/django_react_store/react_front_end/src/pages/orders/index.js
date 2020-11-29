import React, { useEffect, useState, useContext } from "react";
import PageLayout from "../../components/page-layout";
import { useHistory } from "react-router-dom";
import executeAuthGetRequest from "../../utils/executeAuthGETRequest";
import NotificationContext from "../../NotificationContext";
import ListUserOrders from "../../components/user-orders/user-list";

const OrdersPage = () => {
  const notifications = useContext(NotificationContext);
  const history = useHistory();

  const [orders, setOrders] = useState([]);

  const getUserInfo = async () => {
    await executeAuthGetRequest(
      `http://127.0.0.1:8000/api/orders/all/`,
      (response) => {
        if (response.order_set && response.order_set.length) {
          setOrders(
            response.order_set.sort((a, b) =>
              ("" + b.created_at).localeCompare("" + a.created_at)
            )
          );
        }
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push("/");
      }
    );
  };

  useEffect(() => {
    getUserInfo();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  if (!orders) {
    return <PageLayout>Loading...</PageLayout>;
  }

  return (
    <PageLayout>
      <div className="container">
        <hr />
        <div>
          <h4 className="text-center">Orders history</h4>

          {orders && orders.length ? (
            <ListUserOrders orders={orders} />
          ) : (
            <p> There are no orders from you yet.</p>
          )}
        </div>
      </div>
    </PageLayout>
  );
};

export default OrdersPage;
