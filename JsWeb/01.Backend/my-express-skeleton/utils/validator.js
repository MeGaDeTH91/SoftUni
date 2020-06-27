const { body } = require("express-validator");

module.exports = {
  userValidation: [
    body("email", "Invalid email provided.").isEmail(),
    body("password", "Password should be at least 6 characters.").isLength({
      min: 6,
    }),
  ],
  trippValidations: [
    body(
      "startAndEndPoint",
      'The Startpoint - Endpoint input field should include " - " and be at least 11 characters.'
    ).custom((value) => {
      if (!value.includes(" - ")) {
        throw new Error();
      }
      return true;
    }),
    body(
      "dateTime",
      'The Date - Time input field should include " - " and be at least 15 characters.'
    ).custom((value) => {
      if (!value.includes(" - ")) {
        throw new Error();
      }
      return true;
    }),
    body("carImage", "Car Image should be valid url.").isURL(),
    body("seats", "Seat number should be positive integer.")
      .isInt()
      .custom((value) => {
        if (value <= 0) {
          throw new Error();
        }
        return true;
      }),
    body(
      "description",
      "Description should be at least 10 characters long."
    ).isLength({
      min: 10,
    }),
  ],
};
