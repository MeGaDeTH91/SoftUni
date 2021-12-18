package com.example.restapi.model.response.impl;

import com.example.restapi.model.response.UserResponse;

public class UserAuthResponseModel implements UserResponse {
    private Long id;
    private String username;
    private Boolean isRoot;
    private Boolean isAdministrator;
    private Boolean isActive;
    private String token;

    public UserAuthResponseModel() {
    }

    public UserAuthResponseModel(Long id, String username, Boolean isAdministrator, Boolean isActive, String token) {
        this.id = id;
        this.username = username;
        this.isAdministrator = isAdministrator;
        this.isActive = isActive;
        this.token = token;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public Boolean getRoot() {
        return isRoot;
    }

    @Override
    public void setRoot(Boolean root) {
        isRoot = root;
    }

    public Boolean getAdministrator() {
        return isAdministrator;
    }
    
    @Override
    public void setAdministrator(Boolean administrator) {
        isAdministrator = administrator;
    }

    public Boolean getActive() {
        return isActive;
    }

    @Override
    public void setActive(Boolean active) {
        isActive = active;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }
}
