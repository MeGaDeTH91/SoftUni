const getNavigationRoutes = (user) => {
  const adminLinks = [
    {
      title: "Explore Products",
      link: "/",
    },
    {
      title: "Shop by Category",
      link: "/categories/all",
    },
    {
      title: "Users",
      link: "/users",
    },
    {
      title: "Add Product",
      link: "/products/create",
    },
    {
      title: "Add Category",
      link: "/categories/create",
    },
    {
      title: "Profile",
      link: `/profile-details`,
    },
    {
      title: "ShoppingCart",
      link: `/shopping-cart`,
    },
    {
      title: "Logout",
      link: `/logout`,
    },
  ];

  const authLinks = [
    {
      title: "Explore Products",
      link: "/",
    },
    {
      title: "Shop by Category",
      link: "/categories/all",
    },
    {
      title: "Profile",
      link: `/profile-details`,
    },
    {
      title: "ShoppingCart",
      link: `/shopping-cart`,
    },
    {
      title: "Logout",
      link: `/logout`,
    },
  ];

  const guestLinks = [
    {
      title: "Explore Products",
      link: "/",
    },
    {
      title: "Explore Categories",
      link: "/categories/all",
    },
    {
      title: "Register",
      link: "/register",
    },
    {
      title: "Login",
      link: "/login",
    },
  ];

  if (!user || (user && !user.loggedIn)) {
    return guestLinks;
  }

  const isAdmin = user && user.is_superuser;

  return isAdmin ? adminLinks : authLinks;
};

export default getNavigationRoutes;
