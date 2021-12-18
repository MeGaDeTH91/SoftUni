const authenticate = async (url, body, onSuccess, onFailure) => {
  try {
    const promise = await fetch(url, {
      method: "POST",
      body: JSON.stringify(body),
      headers: {
        "Content-Type": "application/json",
      },
    });

    const response = await promise.json();
    const authToken = response["token"];

    if (!promise.ok) {
      onFailure(`Error occurred: ${response}`);
    } else if (response["username"] && response["active"] && authToken) {
      document.cookie = `x-auth-token=${authToken};SameSite=None;Secure`;
      onSuccess({
        id: response["id"],
        username: response["username"],
        isRoot: response["root"],
        isSuperUser: response["administrator"],
        isActive: response["active"],
      });
    } else {
      onFailure("Account is suspended!");
    }

    
  } catch (error) {
    onFailure(error);
  }
};

export default authenticate;
