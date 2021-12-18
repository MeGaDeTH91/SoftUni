package com.example.restapi.model.service;

import java.time.LocalDateTime;
import java.util.Set;

public class OrderServiceModel extends BaseServiceModel {
    private LocalDateTime created;
    private Set<ProductServiceModel> products;
    private UserServiceModel customer;

    public OrderServiceModel() {
    }

    public LocalDateTime getCreated() {
        return created;
    }

    public void setCreated(LocalDateTime created) {
        this.created = created;
    }

    public Set<ProductServiceModel> getProducts() {
        return products;
    }

    public void setProducts(Set<ProductServiceModel> products) {
        this.products = products;
    }

    public UserServiceModel getCustomer() {
        return customer;
    }

    public void setCustomer(UserServiceModel customer) {
        this.customer = customer;
    }
}
