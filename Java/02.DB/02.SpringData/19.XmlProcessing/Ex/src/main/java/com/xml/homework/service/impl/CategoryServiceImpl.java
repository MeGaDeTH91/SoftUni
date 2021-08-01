package com.xml.homework.service.impl;

import com.xml.homework.model.dto.seed.category.CategorySeedRootDTO;
import com.xml.homework.model.entity.Category;
import com.xml.homework.model.entity.Product;
import com.xml.homework.model.dto.viewModels.category.CategoriesByProductVM;
import com.xml.homework.repository.CategoryRepository;
import com.xml.homework.service.CategoryService;
import com.xml.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.Collectors;

@Service
public class CategoryServiceImpl implements CategoryService {
    private final CategoryRepository categoryRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;

    public CategoryServiceImpl(CategoryRepository categoryRepository, ModelMapper modelMapper, ValidationUtil validationUtil) {
        this.categoryRepository = categoryRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
    }

    @Override
    public void seedCategories(CategorySeedRootDTO categorySeedRootDTO) {
        categorySeedRootDTO.getCategories()
                .stream()
                .filter(validationUtil::isValid)
                .map(categoryDTO -> modelMapper.map(categoryDTO, Category.class))
                .forEach(categoryRepository::save);
    }

    @Override
    public boolean categoriesTableIsEmpty() {
        return this.categoryRepository.count() == 0;
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
    public List<CategoriesByProductVM> getAllCategoriesOrderedByProductsNumber() {
        return categoryRepository
                .findAllCategoriesOrderByProductsDesc()
                .stream()
                .map(this::createCategoryViewModel)
                .collect(Collectors.toList());
    }

    private CategoriesByProductVM createCategoryViewModel(Category category) {
        CategoriesByProductVM categoryWithRevenueVM = new CategoriesByProductVM();

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
