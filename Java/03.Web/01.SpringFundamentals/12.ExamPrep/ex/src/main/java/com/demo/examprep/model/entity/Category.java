package com.demo.examprep.model.entity;

import com.demo.examprep.model.enumerations.CategoryNameEnum;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.Table;

@Entity
@Table(name = "categories")
public class Category extends BaseEntity {
    private CategoryNameEnum name;
    private Integer needed_time;

    public Category() {
    }

    @Enumerated(EnumType.STRING)
    public CategoryNameEnum getName() {
        return name;
    }

    public void setName(CategoryNameEnum name) {
        this.name = name;
    }

    @Column(nullable = false)
    public Integer getNeeded_time() {
        return needed_time;
    }

    public void setNeeded_time(Integer needed_time) {
        this.needed_time = needed_time;
    }
}
