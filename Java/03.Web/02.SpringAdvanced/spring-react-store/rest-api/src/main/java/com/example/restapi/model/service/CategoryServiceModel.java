package com.example.restapi.model.service;

import java.util.Set;

public class CategoryServiceModel extends BaseServiceModel {
    private String title;
    private String imageURL;
    private Set<ProductServiceModel> products;

    public CategoryServiceModel() {
    }

    public CategoryServiceModel(Long id) {
        this.setId(id);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }

    public Set<ProductServiceModel> getProducts() {
        return products;
    }

    public void setProducts(Set<ProductServiceModel> products) {
        this.products = products;
    }
}
