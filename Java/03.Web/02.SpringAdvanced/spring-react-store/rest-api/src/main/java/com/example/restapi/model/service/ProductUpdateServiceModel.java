package com.example.restapi.model.service;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class ProductUpdateServiceModel extends BaseServiceModel {
    private String title;
    private String description;
    private String imageURL;
    private BigDecimal price;
    private Integer quantity;
    private LocalDateTime created;

    public ProductUpdateServiceModel() {
    }

    public ProductUpdateServiceModel(String title, String description, String imageURL,
                                     BigDecimal price, Integer quantity, LocalDateTime created) {
        this.title = title;
        this.description = description;
        this.imageURL = imageURL;
        this.price = price;
        this.quantity = quantity;
        this.created = created;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }

    public LocalDateTime getCreated() {
        return created;
    }

    public void setCreated(LocalDateTime created) {
        this.created = created;
    }

    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }
}
