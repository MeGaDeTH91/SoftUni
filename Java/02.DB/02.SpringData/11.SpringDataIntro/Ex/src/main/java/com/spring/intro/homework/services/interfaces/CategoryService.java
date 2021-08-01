package com.spring.intro.homework.services.interfaces;

import com.spring.intro.homework.models.entity.Category;

import java.io.IOException;
import java.util.Set;

public interface CategoryService {
    void seedCategories() throws IOException;

    Set<Category> getRandomCategories();
}
