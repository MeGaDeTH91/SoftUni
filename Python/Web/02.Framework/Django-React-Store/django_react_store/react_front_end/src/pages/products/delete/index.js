import React, { useState, useEffect, useCallback, useContext } from "react";
import { useHistory, useParams } from "react-router-dom";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import DisabledInput from "../../../components/input/disabled";
import NotificationContext from "../../../NotificationContext";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import TextAreaDisabled from "../../../components/textarea/disabled";
import SubmitButton from "../../../components/buttons/submit";

const DeleteProductPage = () => {
  const history = useHistory();
  const params = useParams();
  const notifications = useContext(NotificationContext);

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [imageURL, setImageURL] = useState("");
  const [price, setPrice] = useState(0.0);
  const [quantity, setQuantity] = useState(0);
  const [categoryTitle, setCategoryTitle] = useState("");

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
      setCategoryTitle(product.category.title);
    }
  }, [history, notifications, params]);

  useEffect(() => {
    getProduct();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/products/delete/${params.id}/`,
      "DELETE",
      {},
      (product) => {
        notifications.showMessage("Product removed successfully!", "success");
        history.push("/");
      },
      (error) => {
        notifications.showMessage(error, "danger");
        history.push(`/products/product-delete/${params.id}`);
      }
    );
  };

  const goBack = (e) => {
      e.preventDefault();

      history.goBack();
  }

  return (
    <PageLayout>
      <CreateProductForm onSubmit={handleSubmit}>
        <Title title="Delete Product" />
        <hr />
        {imageURL ? (
          <img
            src={imageURL}
            width="50%"
            height="50%"
            alt="Product visual representation will appear here."
          />
        ) : null}
        <DisabledInput
          id="title"
          value={title}
          label="Title"
          onChange={(e) => setTitle(e.target.value)}
        ></DisabledInput>
        <TextAreaDisabled
          id="description"
          value={description}
          label="Description"
          onChange={(e) => setDescription(e.target.value)}
        ></TextAreaDisabled>
        <DisabledInput
          type="number"
          id="price"
          value={price}
          label="Price"
          onChange={(e) => setPrice(e.target.value)}
        ></DisabledInput>
        <DisabledInput
          type="number"
          id="quantity"
          value={quantity}
          label="Quantity"
          onChange={(e) => setQuantity(e.target.value)}
        ></DisabledInput>
        <DisabledInput
          id="category"
          value={categoryTitle}
          label="Category"
        ></DisabledInput>
        <SubmitButton title="Delete product" goBack={goBack}/>
      </CreateProductForm>
    </PageLayout>
  );
};

const CreateProductForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default DeleteProductPage;
