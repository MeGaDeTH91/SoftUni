package com.xml.homework.service;

import com.xml.homework.model.dto.seed.category.CategorySeedRootDTO;
import com.xml.homework.model.entity.Category;
import com.xml.homework.model.dto.viewModels.category.CategoriesByProductVM;

import java.io.IOException;
import java.util.List;
import java.util.Set;

public interface CategoryService {
    void seedCategories(CategorySeedRootDTO categorySeedRootDTO) throws IOException;

    boolean categoriesTableIsEmpty();

    Set<Category> getRandomCategories();

    List<CategoriesByProductVM> getAllCategoriesOrderedByProductsNumber();
}
