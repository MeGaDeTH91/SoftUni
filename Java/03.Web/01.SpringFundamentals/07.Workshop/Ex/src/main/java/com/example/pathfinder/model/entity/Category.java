package com.example.pathfinder.model.entity;

import com.example.pathfinder.model.enums.CategoryNamesEnum;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "categories")
public class Category extends BaseEntity {
    private CategoryNamesEnum name;
    private String description;

    public Category() {
    }

    @Enumerated(EnumType.STRING)
    @NotNull
    public CategoryNamesEnum getName() {
        return name;
    }

    public void setName(CategoryNamesEnum name) {
        this.name = name;
    }

    @Column(columnDefinition = "TEXT")
    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
