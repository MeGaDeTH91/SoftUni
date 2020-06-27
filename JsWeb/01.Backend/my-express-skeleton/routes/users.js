const router = require("express").Router();
const handler = require("../handlers/users");
const { userValidation } = require("../utils/validator");
const authenticate = require("../utils/authenticate");

router.get("/login", handler.get.login);
router.get("/register", handler.get.register);
router.get("/logout", authenticate(), handler.get.logout);

router.post("/login", handler.post.login);
router.post("/register", userValidation, handler.post.register);

module.exports = router;
