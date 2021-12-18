import React from "react";
import styles from "./index.module.css";
import { Link } from "react-router-dom";

const TextLink = ({ title, href }) => {
  return (
    <Link to={href} className={styles.link}>
      {title}
    </Link>
  );
};

export default TextLink;
