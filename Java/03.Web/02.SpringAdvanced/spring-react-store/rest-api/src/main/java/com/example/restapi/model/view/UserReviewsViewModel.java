package com.example.restapi.model.view;

import java.time.LocalDateTime;

public class UserReviewsViewModel {
    private String content;
    private LocalDateTime created;
    private String product;

    public UserReviewsViewModel() {
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

    public String getProduct() {
        return product;
    }

    public void setProduct(String product) {
        this.product = product;
    }
}
