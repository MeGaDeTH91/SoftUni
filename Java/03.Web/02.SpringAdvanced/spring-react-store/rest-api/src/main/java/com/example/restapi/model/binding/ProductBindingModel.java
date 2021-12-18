package com.example.restapi.model.binding;

import com.example.restapi.constants.ProductMessages;
import org.hibernate.validator.constraints.URL;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;
import javax.validation.constraints.PositiveOrZero;
import javax.validation.constraints.Size;
import java.math.BigDecimal;

public class ProductBindingModel {
    private String title;
    private String description;
    private String imageURL;
    private BigDecimal price;
    private Integer quantity;
    private Long category;

    public ProductBindingModel() {
    }

    @Size(min = 5, max = 40, message = ProductMessages.TITLE_VALIDATION)
    @NotNull(message = ProductMessages.TITLE_VALIDATION)
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Size(min = 10, max = 250, message = ProductMessages.DESCRIPTION_VALIDATION)
    @NotNull(message = ProductMessages.DESCRIPTION_VALIDATION)
    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @URL(message = ProductMessages.IMAGE_URL_VALIDATION)
    @NotNull(message = ProductMessages.IMAGE_URL_VALIDATION)
    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }

    @Positive(message = ProductMessages.PRICE_VALIDATION)
    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    @PositiveOrZero(message = ProductMessages.QUANTITY_VALIDATION)
    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }

    @NotNull(message = ProductMessages.CATEGORY_VALIDATION)
    @Positive(message = ProductMessages.CATEGORY_VALIDATION)
    public Long getCategory() {
        return category;
    }

    public void setCategory(Long category) {
        this.category = category;
    }
}
