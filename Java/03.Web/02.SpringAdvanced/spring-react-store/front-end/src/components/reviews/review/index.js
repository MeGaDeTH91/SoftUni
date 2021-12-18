import React from "react";
import styles from "./index.module.css";
import reviewLogo from "../../../images/review.png";

const Review = ({ content, author, index, date }) => {

  const formattedDate = date.slice(0, 10); 
  return (
    <div className={styles.container}>
      <img
        src={reviewLogo}
        className={styles["review-image"]}
        alt="review"
      />
      <p className={styles.description}>{`${index + 1} - ${content}`}</p>
      <div>
        <span className={styles.user}>
          <small>Author: </small>
          {author}
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
