package com.demo.examprep.service.impl;

import com.demo.examprep.model.entity.Category;
import com.demo.examprep.model.enumerations.CategoryNameEnum;
import com.demo.examprep.repository.CategoryRepository;
import com.demo.examprep.service.CategoryService;
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
                category.setNeeded_time(catEnum.getTime());

                categoryRepository.save(category);
            }
        }
    }

    @Override
    public Category getCategoryByName(CategoryNameEnum category) {
        return categoryRepository.findByName(category).orElse(null);
    }
}
