import React from "react";
import styles from "./index.module.css";
import Review from "../user-reviews";

const ListUserReviews = ( { reviews } ) => {

  const renderReviews = () => {
    return reviews.map((review, index) => {
      let productName = review.product !== null ? review.product.title : 'Product title not available.';
      return <Review key={index} index={index} content={review.content} product={productName} date={review.created} />;
    });
  };

  return <div className={styles["reviews-wrapper"]}>{renderReviews()}</div>;
};

export default ListUserReviews;
