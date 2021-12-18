package com.java.exam.model.binding;

import com.java.exam.model.enumerations.CategoryNameEnum;
import org.springframework.format.annotation.DateTimeFormat;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.PastOrPresent;
import javax.validation.constraints.Positive;
import javax.validation.constraints.Size;
import java.time.LocalDate;

public class AddShipBindingModel {
    private String name;
    private Long health;
    private Long power;
    private LocalDate created;
    private CategoryNameEnum category;

    public AddShipBindingModel() {
    }

    @Size(min = 2, max = 10, message = "Name must be between 2 and 10 characters.")
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @NotNull(message = "The health must be positive.")
    @Positive(message = "The health must be positive.")
    public Long getHealth() {
        return health;
    }

    public void setHealth(Long health) {
        this.health = health;
    }

    @NotNull(message = "The power must be positive.")
    @Positive(message = "The power must be positive.")
    public Long getPower() {
        return power;
    }

    public void setPower(Long power) {
        this.power = power;
    }

    @DateTimeFormat(pattern = "yyyy-MM-dd")
    @NotNull(message = "Created date cannot be in the future.")
    @PastOrPresent(message = "Created date cannot be in the future.")
    public LocalDate getCreated() {
        return created;
    }

    public void setCreated(LocalDate created) {
        this.created = created;
    }

    @NotNull(message = "You must select the category.")
    public CategoryNameEnum getCategory() {
        return category;
    }

    public void setCategory(CategoryNameEnum category) {
        this.category = category;
    }
}
