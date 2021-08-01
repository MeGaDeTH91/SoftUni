package com.spring.auto.mapper.model.dto.users;

import com.spring.auto.mapper.model.dto.BaseDTO;

import javax.validation.constraints.Email;
import javax.validation.constraints.Pattern;

public class UserLoginDTO implements BaseDTO {
    private String email;
    private String password;

    public UserLoginDTO() {
    }

    public UserLoginDTO(String email, String password) {
        this.email = email;
        this.password = password;
    }

    @Email(message = "Incorrect email.")
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Pattern(regexp = "[a-zA-Z\\d]{6,}", message = "Incorrect username / password")
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
