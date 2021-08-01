package com.json.homework.service;

import com.json.homework.model.viewModels.ProductsInRangeVM;

import java.io.IOException;
import java.math.BigDecimal;
import java.util.List;

public interface ProductService {
    void seedProducts() throws IOException;

    List<ProductsInRangeVM> getAllProductsInPriceRangeWithoutBuyer(BigDecimal lower, BigDecimal upper);
}
