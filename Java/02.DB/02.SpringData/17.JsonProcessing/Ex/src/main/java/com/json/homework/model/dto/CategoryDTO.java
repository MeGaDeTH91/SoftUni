package com.json.homework.model.dto;

import com.google.gson.annotations.Expose;

import javax.validation.constraints.Size;

public class CategoryDTO {
    @Expose
    private String name;

    public CategoryDTO() {
    }

    @Size(min = 3, max = 15)
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
