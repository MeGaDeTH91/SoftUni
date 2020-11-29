import React, { useState, useContext } from "react";
import { useHistory } from "react-router-dom";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import Input from "../../../components/input/active";
import UploadButton from "../../../components/upload-button";
import NotificationContext from "../../../NotificationContext";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import SubmitButton from "../../../components/buttons/submit";

const CreateCategoryPage = () => {
  const history = useHistory();
  const notifications = useContext(NotificationContext);

  const [title, setTitle] = useState("");
  const [imageURL, setImageURL] = useState('');

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

  const goBack = (e) => {
    e.preventDefault();

    history.goBack();
  };
  
  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!title || !imageURL) {
      notifications.showMessage('Please provide unique category title and upload Image.', 'danger');
      return;
    }

    await executeAuthRequest("http://127.0.0.1:8000/api/categories/create/", 
      "POST",
      {
        title,
        imageURL,
      },(product) => {
        notifications.showMessage("Category created successfully!", 'success');
        history.push("/categories/all");
      },
      (error) => {
        notifications.showMessage("Please provide different category title.", 'danger');
        history.push("/categories/create");
      }
    );
  };

  return (
    <PageLayout>
      <CreateCategoryForm onSubmit={handleSubmit}>
        <Title title="Add category" />
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
        <UploadButton
          title="Upload Image"
          id="imageURL"
          label="Image URL"
          onChange={(e) => setImageURL(e.target.value)}
          value={imageURL}
          click={openWidget}
        />
        <SubmitButton title="Add category" goBack={goBack}/>
      </CreateCategoryForm>
    </PageLayout>
  );
};

const CreateCategoryForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default CreateCategoryPage;
