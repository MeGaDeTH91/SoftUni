package com.example.restapi.service;

import com.example.restapi.model.service.CategoryServiceModel;
import com.example.restapi.model.service.CategoryUpdateServiceModel;

import java.util.List;

public interface CategoryService {
    List<CategoryServiceModel> getAll();

    boolean exists(String title);

    CategoryServiceModel create(CategoryServiceModel categoryServiceModel);

    CategoryServiceModel get(Long id);

    CategoryServiceModel update(CategoryUpdateServiceModel map);
}
