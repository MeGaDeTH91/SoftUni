package com.example.restapi.model.service;

import com.example.restapi.model.entity.Product;

import java.time.LocalDateTime;

public class UserReviewServiceModel extends BaseServiceModel {
    private String content;
    private LocalDateTime created;
    private Product product;

    public UserReviewServiceModel() {
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

    public Product getProduct() {
        return product;
    }

    public void setProduct(Product product) {
        this.product = product;
    }
}
