import getCookie from "./getCookie";

const executeAuthGetRequest = async (url, onSuccess, onFailure) => {
  try {
    const promise = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `JWT ${getCookie("x-auth-token")}`,
      },
    });

    const response = await promise.json();

    if (!promise.ok) {
      onFailure(`Error occured: ${response}`);
    } else {
      onSuccess(response);
    }
  } catch (error) {
    
    onFailure("Error occured: ", error);
  }
};

export default executeAuthGetRequest;
