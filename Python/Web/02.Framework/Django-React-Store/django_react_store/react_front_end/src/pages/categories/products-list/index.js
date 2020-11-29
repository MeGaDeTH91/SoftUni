import React, { Component } from "react";
import PageLayout from "../../../components/page-layout";
import Title from "../../../components/title";
import CardDeckComponent from "../../../components/card-deck";
import CardProduct from "../../../components/card-product";
import formatPrice from "../../../utils/priceFormatter";

class CategoryProductsPage extends Component {
  constructor(props) {
    super(props);

    this.state = {
      category: '',
      products: [],
    };
  }

  getProducts = async (id) => {
    const promise = await fetch(`http://127.0.0.1:8000/api/categories/${id}/`);

    const category = await promise.json();

    this.setState({
      category,
      products: category.products,
    });
  };

  componentDidMount() {
    this.getProducts(this.props.match.params.id);
  }

  render() {
    return (
      <PageLayout>
        <div>
          <Title title={`Products in category "${this.state.category.title}"`}></Title>
          <hr />
          {this.state.products && this.state.products.length ? (
            <CardDeckComponent>
              {this.state.products.map((x) => {
                return (
                  <CardProduct
                    key={x.id}
                    productId={x.id}
                    imageURL={x.imageURL}
                    title={x.title}
                    price={formatPrice(x.price)}
                    quantity={x.quantity}
                    category={this.state.category}
                  ></CardProduct>
                );
              })}
            </CardDeckComponent>
          ) : (
            <p>No products or database is down.</p>
          )}
        </div>
      </PageLayout>
    );
  }
}

export default CategoryProductsPage;
