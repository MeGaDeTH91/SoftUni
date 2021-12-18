import React, { useState, useEffect } from "react";
import UserContext from "./UserContext";
import NotificationContext from "./NotificationContext";
import getCookie from "./utils/getCookie";

const App = (props) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);

  const [status, setStatus] = useState(false);
  const [message, setMessage] = useState("");
  const [messageType, setMessageType] = useState("");

  const showMessage = (message, messageType) => {
    setStatus(true);
    setMessage(message);
    setMessageType(messageType);
  };

  const clearMessage = () => {
    setStatus(false);
    setMessage("");
    setMessageType("");
  };

  const logIn = (user) => {

    setUser({
      ...user,
      loggedIn: true,
    });
  };

  const logOut = () => {
    document.cookie =
      "x-auth-token=; expires = Thu, 01 Jan 1970 00:00:00 GMT;SameSite=None;Secure";

    setUser({
      loggedIn: false,
    });
  };

  useEffect(() => {
    const token = getCookie("x-auth-token");

    if (!token) {      
      logOut();
      setLoading(false);
      return;
    }
    
    fetch("http://127.0.0.1:8000/api/verify", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    })
      .then((promise) => {
        if (promise.status === 200) {
          return promise.json();
        }
      })
      .then((response) => {
        logIn({
          id: response["id"],
          username: response["username"],
          isRoot: response["root"],
          isSuperUser: response["administrator"],
          isActive: response["active"],
        });

        setLoading(false);
      })
      .catch((err) => {
        logOut();
      });
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <UserContext.Provider
      value={{
        user,
        logIn,
        logOut,
      }}
    >
      <NotificationContext.Provider
        value={{ status, message, messageType, showMessage, clearMessage }}
      >
        {props.children}
      </NotificationContext.Provider>
    </UserContext.Provider>
  );
};

export default App;
