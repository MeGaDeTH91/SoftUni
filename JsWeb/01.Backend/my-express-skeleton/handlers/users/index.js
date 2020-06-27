const User = require("./User");
const jwt = require("../../utils/jwt");
const { validationResult } = require("express-validator");
const { cookie } = require("../../config/config");

module.exports = {
  get: {
    login(req, res, next) {
      res.render("users/login.hbs", {
        title: "Login User",
      });
    },
    register(req, res, next) {
      res.render("users/register.hbs", {
        title: "Register User",
      });
    },
    logout(req, res, next) {
      req.user = null;
      res.clearCookie(cookie).redirect("/home");
    },
  },
  post: {
    login(req, res, next) {
      const { email, password } = req.body;

      User.findOne({
        email,
      })
        .then((user) => {
          if (!user) {
            throw new Error("Invalid credentials!");
          }
          return Promise.all([user.passwordsMatch(password), user]);
        })
        .then(([match, user]) => {
          if (!match) {
            res.render("users/login.hbs", {
              title: "Login User",
              oldInput: { email, password },
              error: "Invalid credentials!",
            });
            return;
            //next(err); // Add validator
            //return;
          }

          const token = jwt.createToken(user);

          res
            .status(201)
            .cookie(cookie, token, { maxAge: 10800000 })
            .redirect("/home");
        })
        .catch((err) => {
          res.render("users/login.hbs", {
            title: "Login User",
            oldInput: { email, password },
            error: err.message,
          });
        });
    },
    register(req, res, next) {
      const errors = validationResult(req);
      const { email, password, rePassword } = req.body;

      if (!errors.isEmpty()) {
        res.render("users/register.hbs", {
          title: "Register User",
          oldInput: { email, password, rePassword },
          error: errors.array()[0].msg,
        });
        return;
      }

      if (password !== rePassword) {
        res.render("users/register.hbs", {
          title: "Register User",
          oldInput: { email, password, rePassword },
          error: "Passwords do not match!",
        });
        return;
      }

      User.findOne({ email })
        .then((currentUser) => {
          if (currentUser) {
            throw new Error("The given email is already used!");
          }
          return User.create({ email, password });
        })
        .then((createdUser) => {
          return res.redirect("/users/login");
        })
        .catch((err) => {
          res.render("users/register.hbs", {
            title: "Register User",
            oldInput: { email, password, rePassword },
            error: err.message,
          });
          return;
        });
    },
  },
};
