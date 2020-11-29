import React, { useState, useEffect, useCallback, useContext } from "react";
import { useHistory } from "react-router-dom";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import Input from "../../../components/input/active";
import TextAreaActive from "../../../components/textarea/active";
import UploadButton from "../../../components/upload-button";
import CategoryDropdown from "../../../components/category-dropdown";
import NotificationContext from "../../../NotificationContext";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import SubmitButton from "../../../components/buttons/submit";

const CreateProductPage = () => {
  const history = useHistory();
  const notifications = useContext(NotificationContext);

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [imageURL, setImageURL] = useState("");
  const [price, setPrice] = useState(0.0);
  const [quantity, setQuantity] = useState(0);
  const [categoryTitle, setCategoryTitle] = useState("Choose category");
  const [category, setCategory] = useState("");
  const [categories, setCategories] = useState([]);

  const openWidget = () => {
    const widget = window.cloudinary.createUploadWidget(
      {
        cloudName: "devpor11z",
        uploadPreset: "react-course",
      },
      (error, result) => {
        if (result.event === "success") {
          setImageURL(result.info.url);
        }
      }
    );

    widget.open();
  };

  const getCategories = useCallback(async () => {
    const response = await fetch(`http://127.0.0.1:8000/api/categories/all`);

    if (!response.ok) {
      notifications.showMessage("Error occured.", "danger");
      history.push("/error");
    } else {
      const categories = await response.json();

      if (!categories) {
        notifications.showMessage("Error occured.", "danger");
        history.push("/error");
      }

      setCategories(categories);
    }
  }, [history, notifications]);

  useEffect(() => {
    getCategories();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleDropdownSelect = (categoryId, e) => {
    setCategory(categoryId);
    setCategoryTitle(e.target.textContent);
  };

  const goBack = (e) => {
    e.preventDefault();

    history.goBack();
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    if (!title || !description || !imageURL || !category) {
      notifications.showMessage(
        "Please provide product title, description, upload Image and choose category.",
        "danger"
      );
      return;
    }

    if (price <= 0 || quantity <= 0) {
      notifications.showMessage(
        "Please provide valid price and quantity.",
        "danger"
      );
      return;
    }

    await executeAuthRequest(
      "http://127.0.0.1:8000/api/products/create/",
      "POST",
      {
        title,
        description,
        imageURL,
        price,
        quantity,
        category,
      },
      (product) => {
        notifications.showMessage("Product created successfully!", "success");
        history.push("/");
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push("/products/create");
      }
    );
  };

  return (
    <PageLayout>
      <CreateProductForm onSubmit={handleSubmit}>
        <Title title="Add product" />
        <hr />
        {imageURL ? (
          <img
            src={imageURL}
            width="50%"
            height="50%"
            alt="Product visual representation will appear here"
          />
        ) : null}
        <Input
          id="title"
          value={title}
          label="Title"
          onChange={(e) => setTitle(e.target.value)}
        ></Input>
        <TextAreaActive
          id="description"
          value={description}
          label="Description"
          onChange={(e) => setDescription(e.target.value)}
        ></TextAreaActive>
        <UploadButton
          title="Upload Image"
          id="imageURL"
          label="Image URL"
          onChange={(e) => setImageURL(e.target.value)}
          value={imageURL}
          click={openWidget}
        />
        <Input
          type="number"
          id="price"
          value={price}
          label="Price"
          onChange={(e) => setPrice(e.target.value)}
        ></Input>
        <Input
          type="number"
          id="quantity"
          value={quantity}
          label="Quantity"
          onChange={(e) => setQuantity(e.target.value)}
        ></Input>
        <CategoryDropdown
          title={categoryTitle}
          categoriesList={categories}
          handleSelect={handleDropdownSelect}
        />
        <SubmitButton title="Add product" goBack={goBack} />
      </CreateProductForm>
    </PageLayout>
  );
};

const CreateProductForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default CreateProductPage;
