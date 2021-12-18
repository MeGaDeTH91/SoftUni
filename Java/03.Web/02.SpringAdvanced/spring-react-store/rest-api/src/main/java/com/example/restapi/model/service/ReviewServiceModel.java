package com.example.restapi.model.service;

import java.time.LocalDateTime;

public class ReviewServiceModel extends BaseServiceModel {
    private String content;
    private LocalDateTime created;
    private UserServiceModel reviewer;
    private ProductServiceModel product;

    public ReviewServiceModel() {
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public LocalDateTime getCreated() {
        return created;
    }

    public void setCreated(LocalDateTime created) {
        this.created = created;
    }

    public UserServiceModel getReviewer() {
        return reviewer;
    }

    public void setReviewer(UserServiceModel reviewer) {
        this.reviewer = reviewer;
    }

    public ProductServiceModel getProduct() {
        return product;
    }

    public void setProduct(ProductServiceModel product) {
        this.product = product;
    }
}
