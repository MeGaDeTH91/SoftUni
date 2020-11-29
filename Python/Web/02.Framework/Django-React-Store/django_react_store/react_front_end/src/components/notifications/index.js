import React, { useContext } from "react";
import { Alert } from "react-bootstrap";
import NotificationContext from "../../NotificationContext";
import styles from './index.module.css'

const PopUp = () => {
  const notificationContext = useContext(NotificationContext);

  const closeNotification = () => {
    notificationContext.clearMessage();
  }

  const popUpNotification = () => {
    return (
      <Alert variant={notificationContext.messageType} className={styles.pop} onClose={closeNotification} dismissible>
        <Alert.Heading>{notificationContext.message}</Alert.Heading>
      </Alert>
    );
  };

  const showNotification = () => {
    setTimeout(() => {
      closeNotification()
    }, 3500);
    return popUpNotification();
  }

  return notificationContext.status ? showNotification() : null;
};

export default PopUp;
