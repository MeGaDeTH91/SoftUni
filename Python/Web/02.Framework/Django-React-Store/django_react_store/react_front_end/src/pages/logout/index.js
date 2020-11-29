import React, { useContext, useEffect } from "react";
import UserContext from "../../UserContext";
import { Redirect } from "react-router-dom";
import NotificationContext from "../../NotificationContext";

const LogoutPage = () => {
  const context = useContext(UserContext);
  const notifications = useContext(NotificationContext);
  
  useEffect(() => {
    context.logOut();
    notifications.showMessage('Logged out successfully!', 'success');
  })

  return (
    <Redirect to="/"/>
  );
}

export default LogoutPage;
