package com.example.restapi.model.binding;

import com.example.restapi.constants.UserMessages;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class UserUpdateBindingModel {
    private String email;
    private String firstName;
    private String lastName;
    private String address;

    public UserUpdateBindingModel() {
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
}
