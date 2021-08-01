package com.xml.homework.service.impl;

import com.xml.homework.model.dto.seed.product.ProductSeedRootDTO;
import com.xml.homework.model.entity.Product;
import com.xml.homework.model.entity.User;
import com.xml.homework.model.dto.viewModels.product.ProductsInRangeVM;
import com.xml.homework.repository.ProductRepository;
import com.xml.homework.service.CategoryService;
import com.xml.homework.service.ProductService;
import com.xml.homework.service.UserService;
import com.xml.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductServiceImpl implements ProductService {
    private static final String PRODUCTS_FILE_PATH = "products.xml";

    private final ProductRepository productRepository;
    private final UserService userService;
    private final CategoryService categoryService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;

    public ProductServiceImpl(ProductRepository productRepository, UserService userService,
                              CategoryService categoryService, ModelMapper modelMapper, ValidationUtil validationUtil) {
        this.productRepository = productRepository;
        this.userService = userService;
        this.categoryService = categoryService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
    }

    @Override
    public void seedProducts(ProductSeedRootDTO productSeedRootDTO) {
        productSeedRootDTO.getProducts()
                .stream()
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

    @Override
    public boolean productsTableIsEmpty() {
        return this.productRepository.count() == 0;
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
