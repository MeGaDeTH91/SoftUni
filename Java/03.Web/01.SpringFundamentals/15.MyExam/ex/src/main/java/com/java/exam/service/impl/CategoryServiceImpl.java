package com.java.exam.service.impl;

import com.java.exam.model.entity.Category;
import com.java.exam.model.enumerations.CategoryNameEnum;
import com.java.exam.repository.CategoryRepository;
import com.java.exam.service.CategoryService;
import org.springframework.stereotype.Service;

@Service
public class CategoryServiceImpl implements CategoryService {
    private final CategoryRepository categoryRepository;

    public CategoryServiceImpl(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @Override
    public void initCategories() {
        if (categoryRepository.count() == 0) {
            Category category;
            for (CategoryNameEnum catEnum: CategoryNameEnum.values()) {
                category = new Category();
                category.setName(catEnum);

                categoryRepository.save(category);
            }
        }
    }

    @Override
    public Category getCategoryByName(CategoryNameEnum category) {
        return categoryRepository.findByName(category).orElse(null);
    }
}
