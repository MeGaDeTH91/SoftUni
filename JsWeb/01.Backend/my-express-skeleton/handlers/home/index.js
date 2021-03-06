module.exports = {
  get: {
    home(req, res, next) {
      res.render("home/home.hbs", {
        title: "Home",
        loggedUser: req.user !== undefined,
        loggedEmail: req.user ? req.user.email : "",
      });
    },
  },
  post: {},
};
