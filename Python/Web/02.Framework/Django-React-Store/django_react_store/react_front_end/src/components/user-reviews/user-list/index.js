import React from "react";
import styles from "./index.module.css";
import Review from "../user-reviews";

const ListUserReviews = ( { reviews } ) => {

  const renderReviews = () => {
    return reviews.map((review, index) => {
      return <Review key={review.id} index={index} content={review.content} product={review.product_title} date={review.created_at} />;
    });
  };

  return <div className={styles["reviews-wrapper"]}>{renderReviews()}</div>;
};

export default ListUserReviews;
