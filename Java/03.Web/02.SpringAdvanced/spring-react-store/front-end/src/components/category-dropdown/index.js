import React from "react";
import { Dropdown, ButtonGroup } from "react-bootstrap";
import CategoryDropdownItem from "../category-dropdown-item";
import styles from "./index.module.css";

const CategoryDropdown = ({ title, categoriesList, handleSelect }) => {
  return (
    <div className={styles["form-control-div"]}>
      <label htmlFor="categories-dropdown" className={styles.label}>
        Category:
      </label>
      <Dropdown as={ButtonGroup} onSelect={handleSelect}>
        <Dropdown.Toggle className={styles.dropdown} id="dropdown-option">{title}</Dropdown.Toggle>
        <Dropdown.Menu >
          {categoriesList.map((x) => {
            return (
              <CategoryDropdownItem
                key={x.title}
                category={x}
              />
            );
          })}
        </Dropdown.Menu>
      </Dropdown>
    </div>
  );
};

export default CategoryDropdown;
