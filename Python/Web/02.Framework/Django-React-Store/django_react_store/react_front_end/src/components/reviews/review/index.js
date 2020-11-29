import React from "react";
import styles from "./index.module.css";
import reviewLogo from "../../../images/review.png";

const Review = ({ content, first_name, last_name, index, date }) => {

  const formattedDate = date.slice(0, 10); 
  return (
    <div className={styles.container}>
      <img
        src={reviewLogo}
        className={styles["review-image"]}
        alt="review"
      ></img>
      <p className={styles.description}>{`${index + 1} - ${content}`}</p>
      <div>
        <span className={styles.user}>
          <small>Author: </small>
          {first_name} {last_name}
        </span>
      </div>
      <div>
        <span className={styles.user}>
          <small>Published: </small>
          {formattedDate}
        </span>
      </div>
    </div>
  );
};

export default Review;
