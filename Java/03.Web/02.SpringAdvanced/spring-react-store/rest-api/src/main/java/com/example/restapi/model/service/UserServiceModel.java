package com.example.restapi.model.service;

import java.util.Set;

public class UserServiceModel extends BaseServiceModel {
    private String username;
    private String password;
    private String email;
    private String address;

    private String firstName;
    private String lastName;

    private boolean accountNonLocked;
    private boolean enabled;

    private ShoppingCartServiceModel cart;
    private Set<ReviewServiceModel> reviews;
    private Set<RoleServiceModel> authorities;

    public UserServiceModel() {
    }

    @Override
    public String toString() {
        return firstName + " " + lastName;
    }

    public UserServiceModel(String username, String password, String email, String firstName, String lastName) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

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

    public ShoppingCartServiceModel getCart() {
        return cart;
    }

    public void setCart(ShoppingCartServiceModel cart) {
        this.cart = cart;
    }

    public Set<RoleServiceModel> getAuthorities() {
        return authorities;
    }

    public void setAuthorities(Set<RoleServiceModel> authorities) {
        this.authorities = authorities;
    }

    public Set<ReviewServiceModel> getReviews() {
        return reviews;
    }

    public void setReviews(Set<ReviewServiceModel> reviews) {
        this.reviews = reviews;
    }

    public boolean isAccountNonLocked() {
        return accountNonLocked;
    }

    public void setAccountNonLocked(boolean accountNonLocked) {
        this.accountNonLocked = accountNonLocked;
    }

    public boolean isEnabled() {
        return enabled;
    }

    public void setEnabled(boolean enabled) {
        this.enabled = enabled;
    }
}
