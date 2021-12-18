import React, { useEffect } from "react";
import Header from "../../components/header";
import Footer from "../../components/footer";
import styles from "./index.module.css";
import PopUp from "../notifications";

const PageLayout = (props) => {
  const showNotification = () => {
    return <PopUp />;
  };

  useEffect(() => {
    showNotification();
  }, []);
  return (
    <div>
      <Header />
      <div className={styles.container}>
        {showNotification()}
        <div className={styles["inner-container"]}>{props.children}</div>
      </div>
      <Footer />
    </div>
  );
};

export default PageLayout;
