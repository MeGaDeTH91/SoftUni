import React, { Component } from "react";
import PageLayout from "../../../components/page-layout";
import UserContext from "../../../UserContext";
import AddButton from "../../../components/buttons/add-to-cart";
import EditButton from "../../../components/buttons/edit";
import DeleteButton from "../../../components/buttons/delete";
import ListReviews from "../../../components/reviews/list";
import styled from "styled-components";
import TextAreaActive from "../../../components/textarea/active";
import executeAuthRequest from "../../../utils/executeAuthRequest";
import formatPrice from "../../../utils/priceFormatter";

class ProductDetailsPage extends Component {
  static contextType = UserContext;

  constructor(props) {
    super(props);

    this.state = {
      product: null,
      show: false,
      review: "",
      reviews: [],
    };
  }

  getProduct = async (productId) => {
    const response = await fetch(
      `http://127.0.0.1:8000/api/products/${productId}/`
    );

    if (!response.ok) {
      this.props.history.push("/");
    }

    const result = await response.json();

    this.setState({
      product: result,
      reviews: result.review_set.sort((a, b) =>
        ("" + b.created_at).localeCompare("" + a.created_at)
      ),
    });
  };

  editProduct = () => {
    this.props.history.push(`/products/product-edit/${this.state.product.id}`);
  };

  deleteProduct = () => {
    this.props.history.push(
      `/products/product-delete/${this.state.product.id}`
    );
  };

  addProductToCart = async (productId) => {
    const userId = this.context.user.id;

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/orders/add-to-cart/${productId}/`,
      "POST",
      {
        userId
      },
      (product) => {
        console.log("Product added successfully in shopping cart.");
      },
      (error) => {
        console.log("Error: ", error);
      }
    );

    this.props.history.push("/");
  };

  componentDidMount() {
    this.getProduct(this.props.match.params.id);
  }

  ReviewSection = () => (
    <div id="results" className="search-results">
      Some Results
    </div>
  );

  showHiddenDiv = () => {
    const { user } = this.context;
    const userIsLogged = user && user.loggedIn;

    return (
      <div>
        <h4 className="text-center">Product reviews</h4>

        {userIsLogged ? (
          <CreateProductForm onSubmit={this.handleSubmit}>
            <h6 className="text-center">
              You own this product? Please share your feedback...
            </h6>
            <TextAreaActive
              id="review"
              value={this.state.review}
              label="Create review"
              onChange={(e) => this.handleChange(e, "review")}
            ></TextAreaActive>
            <AddButton title="Post review" />
          </CreateProductForm>
        ) : null}

        {this.state.reviews && this.state.reviews.length ? (
          <ListReviews reviews={this.state.reviews} />
        ) : (
          <p> There are no reviews for this product yet.</p>
        )}
      </div>
    );
  };

  handleSubmit = async (e) => {
    e.preventDefault();

    await executeAuthRequest(
      `http://127.0.0.1:8000/api/products/create-review/${this.state.product.id}/`,
      "POST",
      {
        content: this.state.review,
        reviewer: this.context.user.id,
      },
      (review) => {
        setTimeout(() => {
          window.location.reload();
        }, 2000);
      },
      (error) => {
        console.log("Error: ", error);
      }
    );
  };

  handleChange = (event, type) => {
    const newState = {};
    newState[type] = event.target.value;

    this.setState(newState);
  };

  toggleShow = () => {
    const newState = {};
    newState["show"] = !this.state.show;

    this.setState(newState);
  };

  render() {
    const { product } = this.state;

    if (!product) {
      return <PageLayout>Loading...</PageLayout>;
    }

    const { user } = this.context;
    const userIsAdministrator = user && user.is_superuser;
    const userIsLogged = user && user.loggedIn;

    return (
      <PageLayout>
        <div className="container">
          <h1 className="my-4">{product.title}</h1>

          <div className="row">
            <div className="col-md-8">
              <img className="img-fluid" src={product.imageURL} alt="Express" />
            </div>

            <div className="col-md-4 text-center">
              <h3 className="my-3">Product Description</h3>
              <p>{product.description}</p>
              <h3 className="my-3">Price: {formatPrice(product.price)}lv</h3>
              <h6 className="my-3"><i>Pieces left: {product.quantity}</i></h6>

              {userIsLogged && (product && product.quantity > 0 ) ? (
                <AddButton
                  title="Add to cart"
                  onClick={(e) => this.addProductToCart(product.id)}
                />
              ) : null}
              {userIsAdministrator ? (
                <EditButton
                  title="Edit product"
                  onClick={this.editProduct}
                ></EditButton>
              ) : null}
              {userIsAdministrator ? (
                <DeleteButton
                  title="Delete product"
                  onClick={this.deleteProduct}
                ></DeleteButton>
              ) : null}
            </div>
          </div>
          <hr />
          {!this.state.show ? (
            <AddButton title="Show reviews section" onClick={this.toggleShow} />
          ) : (
            this.showHiddenDiv()
          )}
        </div>
      </PageLayout>
    );
  }
}

const CreateProductForm = styled.form`
  width: 100%;
  display: inline-block;
  vertical-align: top;
`;

export default ProductDetailsPage;
