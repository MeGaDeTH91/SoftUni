import React from "react";
import PageLayout from "../../components/page-layout";
import Title from "../../components/title";
import styles from "./index.module.css";
import logo from '../../images/hmm_emoji.png'

const ErrorPage = () => {
  return (
    <PageLayout>
      <div className={styles["error-container"]}>
        <Title title="Something went wrong..." />
        <img className={styles["error-img"]} src={logo} alt="hmm emoji"></img>
      </div>
    </PageLayout>
  );
};

export default ErrorPage;
