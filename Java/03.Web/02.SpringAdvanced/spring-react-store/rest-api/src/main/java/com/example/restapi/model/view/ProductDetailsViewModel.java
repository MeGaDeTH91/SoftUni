package com.example.restapi.model.view;

import com.example.restapi.model.service.ShoppingCartServiceModel;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.Set;

public class ProductDetailsViewModel {
    private Long id;
    private String title;
    private String description;
    private String imageURL;
    private BigDecimal price;
    private Integer quantity;
    private LocalDateTime created;
    private CategoryListViewModel category;
    private Set<ShoppingCartServiceModel> carts;
    private Set<ProductReviewsViewModel> reviews;

    public ProductDetailsViewModel() {
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

    public CategoryListViewModel getCategory() {
        return category;
    }

    public void setCategory(CategoryListViewModel category) {
        this.category = category;
    }

    public Set<ProductReviewsViewModel> getReviews() {
        return reviews;
    }

    public void setReviews(Set<ProductReviewsViewModel> reviews) {
        this.reviews = reviews;
    }

    public Set<ShoppingCartServiceModel> getCarts() {
        return carts;
    }

    public void setCarts(Set<ShoppingCartServiceModel> carts) {
        this.carts = carts;
    }
}
