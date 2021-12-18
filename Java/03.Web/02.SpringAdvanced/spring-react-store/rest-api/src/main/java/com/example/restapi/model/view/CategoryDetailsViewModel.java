package com.example.restapi.model.view;

import java.util.Set;

public class CategoryDetailsViewModel {
    private Long id;
    private String title;
    private String imageURL;
    private Set<CategoryProductsViewModel> products;

    public CategoryDetailsViewModel() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
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

    public Set<CategoryProductsViewModel> getProducts() {
        return products;
    }

    public void setProducts(Set<CategoryProductsViewModel> products) {
        this.products = products;
    }
}
