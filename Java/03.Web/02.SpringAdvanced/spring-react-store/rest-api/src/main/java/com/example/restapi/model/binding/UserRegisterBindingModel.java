package com.example.restapi.model.binding;

import com.example.restapi.constants.UserMessages;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class UserRegisterBindingModel {
    private String username;
    private String email;
    private String firstName;
    private String lastName;
    private String address;
    private String password;
    private String confirmPassword;

    public UserRegisterBindingModel() {
    }

    @Size(min = 3, max = 25, message = UserMessages.USERNAME_VALIDATION)
    @NotNull(message = UserMessages.USERNAME_VALIDATION)
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    @Size(min = 3, max = 30, message = UserMessages.FIRST_NAME_VALIDATION)
    @NotNull(message = UserMessages.FIRST_NAME_VALIDATION)
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Size(min = 3, max = 30, message = UserMessages.LAST_NAME_VALIDATION)
    @NotNull(message = UserMessages.LAST_NAME_VALIDATION)
    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    @Size(min = 1, message = UserMessages.EMAIL_VALIDATION)
    @Email(message = UserMessages.EMAIL_VALIDATION)
    @NotNull(message = UserMessages.EMAIL_VALIDATION)
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Size(min = 3, message = UserMessages.PASSWORD_VALIDATION)
    @NotNull(message = UserMessages.PASSWORD_VALIDATION)
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Size(min = 3, message = UserMessages.PASSWORD_VALIDATION)
    @NotNull(message = UserMessages.PASSWORD_VALIDATION)
    public String getConfirmPassword() {
        return confirmPassword;
    }

    public void setConfirmPassword(String confirmPassword) {
        this.confirmPassword = confirmPassword;
    }
}
