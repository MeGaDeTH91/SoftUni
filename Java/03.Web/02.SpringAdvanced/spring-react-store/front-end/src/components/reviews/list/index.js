import React from "react";
import styles from "./index.module.css";
import Review from "../review";

const ListReviews = ( { reviews } ) => {

  const renderReviews = () => {
    return reviews.map((review, index) => {
      return <Review key={index} index={index} content={review.content} author={review.reviewer} date={review.created} />;
    });
  };

  return <div className={styles["reviews-wrapper"]}>{renderReviews()}</div>;
};

export default ListReviews;
