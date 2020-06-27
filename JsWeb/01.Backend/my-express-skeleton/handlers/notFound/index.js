module.exports = {
  get: {
    notFound(req, res, next) {
      res.render("404", {
        title: "Not Found",
        loggedUser: req.user !== undefined,
        loggedEmail: req.user ? req.user.email : "",
      });
    },
  },
  post: {},
};
