import React, { useState, useEffect, useCallback, useContext } from "react";
import { useHistory, useParams } from "react-router-dom";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import Input from "../../../components/input/active";
import DisabledInput from "../../../components/input/disabled";
import TextAreaActive from "../../../components/textarea/active";
import UploadButton from "../../../components/upload-button";
import NotificationContext from "../../../NotificationContext";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import SubmitButton from "../../../components/buttons/submit";

const EditProductPage = () => {
  const history = useHistory();
  const params = useParams();
  const notifications = useContext(NotificationContext);

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [imageURL, setImageURL] = useState("");
  const [price, setPrice] = useState(0.0);
  const [quantity, setQuantity] = useState(0);
  const [category, setCategory] = useState("");
  const [categoryTitle, setCategoryTitle] = useState("");

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

  const getProduct = useCallback(async () => {
    const response = await fetch(
      `http://127.0.0.1:8000/api/products/${params.id}/`
    );

    if (!response.ok) {
      notifications.showMessage("Invalid productId.", "danger");
      history.push("/");
    } else {
      const product = await response.json();

      if (!product) {
        notifications.showMessage("No such product.", "danger");
        history.push("/");
      }

      setTitle(product.title);
      setDescription(product.description);
      setImageURL(product.imageURL);
      setPrice(product.price);
      setQuantity(product.quantity);
      setTitle(product.title);
      setCategory(product.category.id);
      setCategoryTitle(product.category.title);
    }
  }, [history, notifications, params]);

  useEffect(() => {
    getProduct();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const goBack = (e) => {
    e.preventDefault();

    history.goBack();
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!title || !description || !imageURL) {
      notifications.showMessage(
        "Please provide product title, description and upload Image.",
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
      `http://127.0.0.1:8000/api/products/edit/${params.id}/`,
      "PUT",
      {
        title,
        description,
        imageURL,
        price,
        quantity,
        category,
      },
      (product) => {
        notifications.showMessage("Product changed successfully!", "success");
        history.push("/");
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push(`/products/product-edit/${params.id}`);
      }
    );
  };

  return (
    <PageLayout>
      <CreateProductForm onSubmit={handleSubmit}>
        <Title title="Edit product" />
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
        <DisabledInput
          id="category"
          value={categoryTitle}
          label="Category"
        ></DisabledInput>
        <SubmitButton title="Change product" goBack={goBack} />
      </CreateProductForm>
    </PageLayout>
  );
};

const CreateProductForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default EditProductPage;
