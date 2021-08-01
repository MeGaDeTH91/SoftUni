package com.json.homework.service.impl;

import com.google.gson.Gson;
import com.json.homework.constants.GlobalConstants;
import com.json.homework.model.dto.ProductDTO;
import com.json.homework.model.entity.Product;
import com.json.homework.model.entity.User;
import com.json.homework.model.viewModels.ProductsInRangeVM;
import com.json.homework.repository.ProductRepository;
import com.json.homework.service.CategoryService;
import com.json.homework.service.ProductService;
import com.json.homework.service.UserService;
import com.json.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductServiceImpl implements ProductService {
    private static final String PRODUCTS_FILE_PATH = "products.json";

    private final ProductRepository productRepository;
    private final UserService userService;
    private final CategoryService categoryService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public ProductServiceImpl(ProductRepository productRepository, UserService userService,
                              CategoryService categoryService, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.productRepository = productRepository;
        this.userService = userService;
        this.categoryService = categoryService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public void seedProducts() throws IOException {
        if (productRepository.count() < 1) {
            Arrays.stream(gson
                    .fromJson(Files.readString(Path.of(GlobalConstants.SEED_RESOURCES_FILE_PATH + PRODUCTS_FILE_PATH)),
                            ProductDTO[].class))
                    .filter(validationUtil::isValid)
                    .map(productDTO -> {
                        Product product = modelMapper.map(productDTO, Product.class);

                        product.setSeller(userService.getRandomSeller());

                        if (product.getPrice().compareTo(BigDecimal.valueOf(300)) > 0 &&
                                product.getPrice().compareTo(BigDecimal.valueOf(700)) < 0) {
                            product.setBuyer(userService.getRandomBuyerDifferentFromSeller(product.getSeller().getId()));
                        }

                        product.setCategories(categoryService.getRandomCategories());

                        return product;
                    })
                    .forEach(productRepository::save);
        }
    }

    @Override
    public List<ProductsInRangeVM> getAllProductsInPriceRangeWithoutBuyer(BigDecimal lower, BigDecimal upper) {
        return productRepository
                .findAllByPriceBetweenAndBuyerIsNull(lower, upper)
                .stream()
                .map(product -> {
                    ProductsInRangeVM productViewModel = modelMapper.map(product, ProductsInRangeVM.class);

                    String sellerName;
                    User seller = product.getSeller();
                    if (seller.getFirstName() == null) {
                        sellerName = seller.getLastName();
                    } else {
                        sellerName = String.format("%s %s", seller.getFirstName(), seller.getLastName());
                    }

                    productViewModel.setSeller(sellerName);

                    return productViewModel;
                })
                .collect(Collectors.toList());
    }
}
