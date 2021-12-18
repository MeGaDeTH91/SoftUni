package com.example.restapi.model.binding;

import com.example.restapi.constants.UserMessages;

import javax.validation.constraints.Size;

public class UserLoginBindingModel {
    private String username;
    private String password;

    public UserLoginBindingModel() {
    }

    @Size(min = 3, max = 25, message = UserMessages.USERNAME_VALIDATION)
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    @Size(min = 3, message = UserMessages.PASSWORD_VALIDATION)
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
