package com.example.restapi.model.service;

import java.util.Set;

public class ShoppingCartServiceModel extends BaseServiceModel {
    private Set<ProductServiceModel> products;

    public ShoppingCartServiceModel() {
    }

    public Set<ProductServiceModel> getProducts() {
        return products;
    }

    public void setProducts(Set<ProductServiceModel> products) {
        this.products = products;
    }
}
