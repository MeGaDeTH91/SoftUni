import React, { useContext } from "react";
import { Alert } from "react-bootstrap";
import NotificationContext from "../../NotificationContext";
import styles from './index.module.css'
import os from 'os'

const PopUp = () => {
  const notificationContext = useContext(NotificationContext);

  const closeNotification = () => {
    notificationContext.clearMessage();
  }

  const popUpNotification = () => {
    let inputMessage = notificationContext.message;
    let message = '';

    if(Object.prototype.toString.call(inputMessage) === '[object Array]') {
      inputMessage.forEach(element => message += element + JSON.stringify(os.EOL));
    } else {
      message = inputMessage;
    }
    return (
      <Alert variant={notificationContext.messageType} className={styles.pop} onClose={closeNotification} dismissible>
        <Alert.Heading>{message}</Alert.Heading>
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
