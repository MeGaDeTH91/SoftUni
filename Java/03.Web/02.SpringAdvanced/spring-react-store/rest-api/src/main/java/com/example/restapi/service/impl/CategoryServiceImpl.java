package com.example.restapi.service.impl;

import com.example.restapi.model.entity.Category;
import com.example.restapi.model.service.CategoryServiceModel;
import com.example.restapi.model.service.CategoryUpdateServiceModel;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.repository.CategoryRepository;
import com.example.restapi.service.CategoryService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CategoryServiceImpl implements CategoryService {
    private final CategoryRepository categoryRepository;
    private final ModelMapper modelMapper;

    public CategoryServiceImpl(CategoryRepository categoryRepository, ModelMapper modelMapper) {
        this.categoryRepository = categoryRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public List<CategoryServiceModel> getAll() {
        return categoryRepository
                .findAll()
                .stream()
                .map(product -> modelMapper.map(product, CategoryServiceModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public boolean exists(String title) {
        return categoryRepository.existsByTitle(title);
    }

    @Override
    public CategoryServiceModel create(CategoryServiceModel categoryServiceModel) {
        Category category = modelMapper.map(categoryServiceModel, Category.class);

        return this.modelMapper.map(categoryRepository.saveAndFlush(category), CategoryServiceModel.class);
    }

    @Override
    public CategoryServiceModel get(Long id) {
        Category repoCategory = categoryRepository.findById(id).orElse(null);
        if (repoCategory == null) {
            return null;
        }
        CategoryServiceModel mappedCategory = modelMapper.map(repoCategory, CategoryServiceModel.class);
        if (mappedCategory.getProducts() == null && repoCategory.getProducts() != null) {
            mappedCategory.setProducts(repoCategory
                    .getProducts()
                    .stream()
                    .map(product -> modelMapper.map(product, ProductServiceModel.class))
                    .collect(Collectors.toSet()));
        }
        return mappedCategory;
    }

    @Override
    public CategoryServiceModel update(CategoryUpdateServiceModel categoryUpdateServiceModel) {
        Category category = categoryRepository.findById(categoryUpdateServiceModel.getId()).orElse(null);
        if (category == null) {
            return null;
        }
        modelMapper.map(categoryUpdateServiceModel, category);
        categoryRepository.save(category);

        return modelMapper.map(category, CategoryServiceModel.class);
    }
}
