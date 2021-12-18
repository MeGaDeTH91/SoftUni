package com.example.restapi.model.view;

import com.example.restapi.model.service.ReviewServiceModel;
import com.example.restapi.model.service.RoleServiceModel;
import com.example.restapi.model.service.ShoppingCartServiceModel;

import java.util.Set;

public class UserDetailsViewModel {
    private String username;
    private String email;
    private String address;

    private String firstName;
    private String lastName;

    private ShoppingCartServiceModel cart;
    private Set<RoleServiceModel> authorities;
    private Set<ReviewServiceModel> reviews;

    public UserDetailsViewModel() {
    }

    @Override
    public String toString() {
        return getUsername();
    }

    public UserDetailsViewModel(String username, String email, String firstName, String lastName){
        this.username = username;
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
}
