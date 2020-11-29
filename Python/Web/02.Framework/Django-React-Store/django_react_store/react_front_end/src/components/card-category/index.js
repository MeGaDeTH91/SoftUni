import React, { useContext } from "react";
import { useHistory } from "react-router-dom";
import styled from "styled-components";
import styles from './index.module.css';
import EditButton from "../buttons/edit";
import UserContext from "../../UserContext";

const CardCategory = ({ categoryId, imageURL, title }) => {
  const history = useHistory();
  const context = useContext(UserContext);

  const { user } = context;
  const userIsAdministrator = user && user.is_superuser;

  const onDetails = () => {
    history.push(`/categories/category/${categoryId}`);
  };

  const editCategory = () => {
    history.push(`/categories/category-edit/${categoryId}`);
  };

  return (
    <Card>
      <div className={styles.thumbnail} onClick={onDetails}>
      <CardImage src={imageURL} alt="Card image cap"></CardImage>
      <CardBody>
        <h4>{ title.length > 21 ? (title) : (<div> {title}<br /><br /></div>)}</h4>
        <hr />
      </CardBody>
      </div>
      

      {userIsAdministrator ? (
        <CardFooter>
          <EditButton title="Edit Category" onClick={editCategory}></EditButton>
        </CardFooter>
      ) : null}
    </Card>
  );
};

const Card = styled.div`
  box-sizing: border-box;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
  position: relative;
  min-width: 18rem;
  max-width: 18rem;
  margin-bottom: 1.5rem !important;
  display: flex;
  flex: 1 0 0%;
  flex-direction: column;
  margin-right: 15px;
  margin-bottom: 0;
  margin-left: 50px;
`;

const CardFooter = styled.div`
  border-radius: 0 0 calc(0.25rem - 1px) calc(0.25rem - 1px);
  background-color: #dddddd;
  color: white;
  border-top: 1px solid #dddddd;
  margin: 0;
  padding: 0;
  font-size: medium;
  font-family: "Miltonian Tattoo", cursive;
`;

const CardImage = styled.img`
  width: 100%;
  height: 210px;
  object-fit: cover;
  border-top-left-radius: calc(0.25rem - 1px);
  border-top-right-radius: calc(0.25rem - 1px);
  border-style: none;
  box-sizing: border-box;
`;

const CardBody = styled.div`
  webkit-box-flex: 1;
  ms-flex: 1 1 auto;
  flex: 1 1 auto;
  padding: 1.25rem;
  word-wrap: break-word;
  box-sizing: border-box;
`;

export default CardCategory;
