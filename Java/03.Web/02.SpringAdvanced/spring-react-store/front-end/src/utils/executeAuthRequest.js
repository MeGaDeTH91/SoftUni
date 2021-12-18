import getCookie from "../utils/getCookie";

const executeAuthRequest = async (url, method, body, onSuccess, onFailure) => {
  try {
    const promise = await fetch(url, {
      method,
      body: JSON.stringify(body),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getCookie("x-auth-token")}`,
      },
    });

    const response = await promise.json();

    if (!promise.ok) {
      onFailure(`Error occurred: ${response.message}`);
    } else {
      onSuccess(response);
    }
  } catch (error) {
    onFailure("Error occurred: ", error);
  }
};

export default executeAuthRequest;
