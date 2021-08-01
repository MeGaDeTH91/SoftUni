package com.json.homework.service.impl;

import com.google.gson.Gson;
import com.json.homework.constants.GlobalConstants;
import com.json.homework.model.dto.CategoryDTO;
import com.json.homework.model.entity.Category;
import com.json.homework.model.entity.Product;
import com.json.homework.model.viewModels.CategoryWithRevenueVM;
import com.json.homework.repository.CategoryRepository;
import com.json.homework.service.CategoryService;
import com.json.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.Collectors;

@Service
public class CategoryServiceImpl implements CategoryService {
    private static final String CATEGORIES_FILE_PATH = "categories.json";

    private final CategoryRepository categoryRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public CategoryServiceImpl(CategoryRepository categoryRepository, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.categoryRepository = categoryRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public void seedCategories() throws IOException {
        if (categoryRepository.count() < 1) {
            Arrays.stream(gson
                    .fromJson(Files.readString(Path.of(GlobalConstants.SEED_RESOURCES_FILE_PATH + CATEGORIES_FILE_PATH)),
                            CategoryDTO[].class))
                    .filter(validationUtil::isValid)
                    .map(categoryDto -> modelMapper.map(categoryDto, Category.class))
                    .forEach(categoryRepository::save);
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

    @Override
    public List<CategoryWithRevenueVM> getAllCategoriesOrderedByProductsNumber() {
        return categoryRepository
                .findAllCategoriesOrderByProductsDesc()
                .stream()
                .map(this::createCategoryViewModel)
                .collect(Collectors.toList());
    }

    private CategoryWithRevenueVM createCategoryViewModel(Category category) {
        CategoryWithRevenueVM categoryWithRevenueVM = new CategoryWithRevenueVM();

        int productsCount = category.getProducts().size();
        BigDecimal totalRevenue = category.getProducts().stream().map(Product::getPrice).reduce(BigDecimal.ZERO, BigDecimal::add);
        BigDecimal avgPrice = totalRevenue.divide(BigDecimal.valueOf(category.getProducts().size()), RoundingMode.FLOOR);

        categoryWithRevenueVM.setCategory(category.getName());
        categoryWithRevenueVM.setProductsCount(productsCount);
        categoryWithRevenueVM.setAveragePrice(avgPrice);
        categoryWithRevenueVM.setTotalRevenue(totalRevenue);

        return categoryWithRevenueVM;
    }
}
