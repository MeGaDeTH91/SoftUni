package com.demo.examprep.service;

import com.demo.examprep.model.entity.Category;
import com.demo.examprep.model.enumerations.CategoryNameEnum;

public interface CategoryService {
    void initCategories();

    Category getCategoryByName(CategoryNameEnum category);
}
