package com.example.restapi.constants;

public class UserMessages {
    // Register
    public static final String REGISTRATION_NOT_SUCCESSFUL = "Registration was not successful.";
    public static final String USERNAME_ALREADY_EXISTS = "Username already exists.";

    // Login
    public static final String ACCOUNT_INACTIVE = "User account is not currently active!";
    public static final String INVALID_CREDENTIALS = "Invalid credentials!";
    public static final String INVALID_JWT = "Invalid JWT token!";
    public static final String EMPTY_PRINCIPAL = "Principal cannot be null!";

    // Binding
    public static final String USERNAME_VALIDATION = "Username length must be between 3 and 25 characters.";
    public static final String FIRST_NAME_VALIDATION = "Enter valid first name.";
    public static final String LAST_NAME_VALIDATION = "Enter valid last name.";
    public static final String EMAIL_VALIDATION = "Enter valid email address.";
    public static final String PASSWORD_VALIDATION = "Password length must be more than 3 characters long.";

    // GET
    public static final String NO_USERS_DATA = "No users data available.";
    public static final String USER_DOES_NOT_EXIST = "User not found.";

    // PUT
    public static final String USER_MISMATCH = "Update is available only for currently logged user.";
}
