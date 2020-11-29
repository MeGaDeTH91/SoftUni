import React, {
  useState,
  useEffect,
  useCallback,
  useContext,
} from "react";
import { useHistory, useParams } from "react-router-dom";
import styled from "styled-components";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import Input from "../../../components/input/active";
import UploadButton from "../../../components/upload-button";
import NotificationContext from "../../../NotificationContext";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import SubmitButton from "../../../components/buttons/submit";

const EditCategoryPage = () => {
  const history = useHistory();
  const params = useParams();
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

  const getCategory = useCallback(async () => {
    const response = await fetch(
      `http://127.0.0.1:8000/api/categories/${params.id}/`
    );

    if (!response.ok) {
      notifications.showMessage("Invalid categoryId.", "danger");
      history.push("/");
    } else {
      const category = await response.json();

      if (!category) {
        notifications.showMessage("No such category.", "danger");
        history.push("/");
      }

      setTitle(category.title);
      setImageURL(category.imageURL);
    }
  }, [history, notifications, params]);

  useEffect(() => {
    getCategory();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const goBack = (e) => {
    e.preventDefault();

    history.goBack();
}

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!title || !imageURL) {
      notifications.showMessage(
        "Please provide category title or upload Image.",
        "danger"
      );
      return;
    }

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/categories/${params.id}/`,
      "PUT",
      {
        title,
        imageURL,
      },
      (product) => {
        notifications.showMessage("Category changed successfully!", "success");
        history.push("/categories/all");
      },
      (error) => {
        notifications.showMessage(
          error,
          "danger"
        );
        history.push(`/categories/category-edit/${params.id}`);
      }
    );
  };

  return (
    <PageLayout>
      <EditCategoryForm onSubmit={handleSubmit}>
        <Title title="Edit category" />
        <hr />
        {imageURL ? (
          <img
            src={imageURL}
            width="50%"
            height="50%"
            alt="Product representation"
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
        <SubmitButton title="Change category" goBack={goBack}/>
      </EditCategoryForm>
    </PageLayout>
  );
};

const EditCategoryForm = styled.form`
  width: 83%;
  display: inline-block;
  vertical-align: top;
`;

export default EditCategoryPage;
