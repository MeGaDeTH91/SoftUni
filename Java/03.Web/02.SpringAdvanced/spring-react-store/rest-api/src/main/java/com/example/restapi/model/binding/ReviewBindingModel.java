package com.example.restapi.model.binding;

import com.example.restapi.constants.ReviewMessages;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;
import javax.validation.constraints.Size;

public class ReviewBindingModel {
    private String content;
    private Long reviewer;
    private Long product;

    public ReviewBindingModel() {
    }

    @Size(min = 10, max = 250, message = ReviewMessages.CONTENT_VALIDATION)
    @NotNull(message = ReviewMessages.CONTENT_VALIDATION)
    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    @Positive(message = ReviewMessages.REVIEWER_VALIDATION)
    @NotNull(message = ReviewMessages.REVIEWER_VALIDATION)
    public Long getReviewer() {
        return reviewer;
    }

    public void setReviewer(Long reviewer) {
        this.reviewer = reviewer;
    }

    @Positive(message = ReviewMessages.PRODUCT_VALIDATION)
    @NotNull(message = ReviewMessages.PRODUCT_VALIDATION)
    public Long getProduct() {
        return product;
    }

    public void setProduct(Long product) {
        this.product = product;
    }
}
