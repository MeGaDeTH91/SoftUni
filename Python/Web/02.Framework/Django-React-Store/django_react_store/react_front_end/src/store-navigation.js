import React, { useContext } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import HomePage from "./pages/home";
import ErrorPage from "./pages/error";
import CreateProductPage from "./pages/products/create";
import CreateCategoryPage from "./pages/categories/create";
import RegisterPage from "./pages/register";
import LoginPage from "./pages/login";
import UserContext from "./UserContext";
import LogoutPage from "./pages/logout";
import CategoriesPage from "./pages/categories/all";
import ProductDetailsPage from "./pages/products/details";
import EditProductPage from "./pages/products/edit";
import DeleteProductPage from "./pages/products/delete";
import EditCategoryPage from "./pages/categories/edit";
import UsersPage from "./pages/users/users-list";
import CategoryProductsPage from "./pages/categories/products-list";
import HomeFilteredPage from "./pages/home-filtered";
import ProfilePage from "./pages/profile";
import EditUserPage from "./pages/users/users-edit";
import ShoppingCartPage from "./pages/shopping-cart";
import OrdersPage from "./pages/orders";

const StoreNavigation = () => {
  const context = useContext(UserContext);
  const userIsLogged = context.user && context.user.loggedIn;
  const admin = userIsLogged && context.user.is_superuser;

  const authorizationSwitch = (requiredPrivilege, page, redirectRoute) => {
    return requiredPrivilege ? page : <Redirect to={`${redirectRoute}`} />;
  };

  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route exact path="/search/:search" component={HomeFilteredPage} />
        <Route exact path="/products/product-details/:id" component={ProductDetailsPage} />
        <Route exact path="/categories/all" component={CategoriesPage} />
        <Route exact path="/categories/category/:id" component={CategoryProductsPage} />

        <Route exact path="/products/create">
          {authorizationSwitch(admin, <CreateProductPage />, "/")}
        </Route>
        <Route exact path="/products/product-edit/:id">
          {authorizationSwitch(admin, <EditProductPage />, "/")}
        </Route>
        <Route exact path="/products/product-delete/:id">
          {authorizationSwitch(admin, <DeleteProductPage />, "/")}
        </Route>
        <Route exact path="/categories/create">
          {authorizationSwitch(admin, <CreateCategoryPage />, "/")}
        </Route>
        <Route exact path="/categories/category-edit/:id">
          {authorizationSwitch(admin, <EditCategoryPage />, "/")}
        </Route>
        <Route exact path="/users">
          {authorizationSwitch(admin, <UsersPage/>, "/")}
        </Route>

        <Route exact path="/register">
          {authorizationSwitch(!userIsLogged, <RegisterPage />, "/")}
        </Route>
        <Route exact path="/login">
          {authorizationSwitch(!userIsLogged, <LoginPage />, "/")}
        </Route>

        <Route exact path="/logout">
          {authorizationSwitch(userIsLogged, <LogoutPage />, "/login")}
        </Route>
        <Route exact path="/profile-details">
          {authorizationSwitch(userIsLogged, <ProfilePage />, "/login")}
        </Route>
        <Route exact path="/profile-edit">
          {authorizationSwitch(userIsLogged, <EditUserPage />, "/login")}
        </Route>
        <Route exact path="/shopping-cart">
          {authorizationSwitch(userIsLogged, <ShoppingCartPage />, "/login")}
        </Route>
        <Route exact path="/my-orders">
          {authorizationSwitch(userIsLogged, <OrdersPage />, "/login")}
        </Route>
        <Route component={ErrorPage} />
      </Switch>
    </BrowserRouter>
  );
};

export default StoreNavigation;
