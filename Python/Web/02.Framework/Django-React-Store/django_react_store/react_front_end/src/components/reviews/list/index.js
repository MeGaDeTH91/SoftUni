import React from "react";
import styles from "./index.module.css";
import Review from "../review";

const ListReviews = ( { reviews } ) => {

  const renderReviews = () => {
    return reviews.map((review, index) => {
      return <Review key={review.id} index={index} content={review.content} first_name={review.reviewer.first_name} last_name={review.reviewer.last_name} date={review.created_at} />;
    });
  };

  return <div className={styles["reviews-wrapper"]}>{renderReviews()}</div>;
};

export default ListReviews;
