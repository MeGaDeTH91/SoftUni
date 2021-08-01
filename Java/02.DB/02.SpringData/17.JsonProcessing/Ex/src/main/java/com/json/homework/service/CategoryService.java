package com.json.homework.service;

import com.json.homework.model.entity.Category;
import com.json.homework.model.viewModels.CategoryWithRevenueVM;

import java.io.IOException;
import java.util.List;
import java.util.Set;

public interface CategoryService {
    void seedCategories() throws IOException;

    Set<Category> getRandomCategories();

    List<CategoryWithRevenueVM> getAllCategoriesOrderedByProductsNumber();
}
