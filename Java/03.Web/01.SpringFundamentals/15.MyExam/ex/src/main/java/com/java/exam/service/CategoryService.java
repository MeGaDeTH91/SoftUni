package com.java.exam.service;

import com.java.exam.model.entity.Category;
import com.java.exam.model.enumerations.CategoryNameEnum;

public interface CategoryService {
    void initCategories();

    Category getCategoryByName(CategoryNameEnum category);
}
