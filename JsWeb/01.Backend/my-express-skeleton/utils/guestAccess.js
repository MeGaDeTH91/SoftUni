const { cookie } = require("../config/config");

module.exports = () => {
  return function (req, res, next) {
    const token = req.cookies[cookie];

    if (token) {
      return res.redirect("/home");
    }
    next();
  };
};
