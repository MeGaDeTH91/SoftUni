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
    const authToken = response.token;

    if (!promise.ok) {
      onFailure(`Error occured: ${response}`);
    } else if (response.user.username && response.user.is_active && authToken) {
      document.cookie = `x-auth-token=${authToken};`;
      onSuccess({
        username: response.user.username,
        is_superuser: response.user.is_superuser,
        is_active: response.user.is_active,
        id: response.user.id,
      });
    } else {
      onFailure("Account is suspended!");
    }

    
  } catch (error) {
    onFailure(error);
  }
};

export default authenticate;
