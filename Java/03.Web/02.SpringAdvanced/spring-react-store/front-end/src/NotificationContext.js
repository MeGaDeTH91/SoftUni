import React from "react";

const NotificationContext = React.createContext({
  status: false,
  message: "",
  messageType: "",
  showMessage: () => {},
  clearMessage: () => {},
});

export default NotificationContext;
