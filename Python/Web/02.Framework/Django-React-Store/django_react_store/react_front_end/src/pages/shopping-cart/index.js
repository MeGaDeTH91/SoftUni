import React, { useContext, useState, useEffect } from "react";
import PageLayout from "../../components/page-layout";
import NotificationContext from "../../NotificationContext";
import { useHistory } from "react-router-dom";
import executeAuthGetRequest from "../../utils/executeAuthGETRequest";
import UserContext from "../../UserContext";
import ShoppingCartTable from "../../components/tables/shopping-cart";
import AddButton from "../../components/buttons/add-to-cart";
import executeAuthRequest from "../../utils/executeAuthRequest";

const ShoppingCartPage = () => {
  const userContext = useContext(UserContext);
  const notifications = useContext(NotificationContext);
  const history = useHistory();

  const [cart, setCart] = useState([]);

  const getUserCart = async () => {
    await executeAuthGetRequest(
      `http://127.0.0.1:8000/api/profile-cart/${userContext.user.id}/`,
      (response) => {
        setCart(response.cart);
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push("/users");
      }
    );
  };

  const submitOrder = async () => {
    await executeAuthRequest(
      `http://127.0.0.1:8000/api/orders/create/`,
      "POST",
      {
      },
      (usersResponse) => {
        notifications.showMessage("Order placed successfully!", "success");
      },
      (error) => {
        notifications.showMessage(error, "danger");
      }
    );

    history.push("/shopping-cart");
    setTimeout(() => {
      window.location.reload();
    }, 2000);
  };

  useEffect(() => {
    getUserCart();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  if (!cart) {
    return <PageLayout>Loading...</PageLayout>;
  }

  return (
    <PageLayout>
      <div className="container">
        <br />
        <h1>Your shopping cart</h1>
        <hr />
        <br />
        {cart && cart.length ? (
          <div>
            <ShoppingCartTable products={cart} />
            <AddButton
              title="Place order"
              onClick={submitOrder}
            />
          </div>
        ) : (
          <p>No products in your cart.</p>
        )}
      </div>
    </PageLayout>
  );
};

export default ShoppingCartPage;
