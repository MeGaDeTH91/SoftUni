const validateTextField = (field, message, context) => {
  if (!field) {
    context.showMessage(message, "danger");
    return false;
  }

  return true;
};

export default validateTextField;
