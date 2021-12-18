package com.example.restapi.model.view;

import java.time.LocalDateTime;

public class ProductReviewsViewModel {
    private String content;
    private LocalDateTime created;
    private String reviewer;

    public ProductReviewsViewModel() {
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

    public String getReviewer() {
        return reviewer;
    }

    public void setReviewer(String reviewer) {
        this.reviewer = reviewer;
    }
}
