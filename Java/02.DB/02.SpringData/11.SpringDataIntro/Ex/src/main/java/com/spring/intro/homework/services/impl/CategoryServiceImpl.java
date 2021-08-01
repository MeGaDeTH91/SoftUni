package com.spring.intro.homework.services.impl;

import com.spring.intro.homework.models.entity.Category;
import com.spring.intro.homework.repositories.CategoryRepository;
import com.spring.intro.homework.services.interfaces.CategoryService;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashSet;
import java.util.Set;
import java.util.concurrent.ThreadLocalRandom;

@Service
public class CategoryServiceImpl implements CategoryService {

    private static final String CATEGORIES_FILE_PATH = "src/main/resources/files/categories.txt";

    private final CategoryRepository categoryRepository;

    public CategoryServiceImpl(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @Override
    public void seedCategories() throws IOException {
        if(categoryRepository.count() < 1) {
            Files.readAllLines(Path.of(CATEGORIES_FILE_PATH))
                    .stream()
                    .filter(category -> !category.isEmpty())
                    .forEach(row -> {
                        String[] rowTokens = row.split("\\s+");
                        Category category = new Category(rowTokens[0]);

                        categoryRepository.save(category);
                    });
        }
    }

    @Override
    public Set<Category> getRandomCategories() {
        Set<Category> categories = new HashSet<>();
        
        int categoriesToAddCount = ThreadLocalRandom
                .current()
                .nextInt(1, 4);

        long categoriesAllCount = categoryRepository.count() + 1;

        long randomCategoryId;
        for (int i = 0; i < categoriesToAddCount; i++) {
            randomCategoryId = ThreadLocalRandom
                    .current()
                    .nextLong(1, categoriesAllCount);

            Category category = categoryRepository.findById(randomCategoryId).orElse(null);

            categories.add(category);
        }

        return categories;
    }
}
