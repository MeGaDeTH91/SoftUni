package com.xml.homework.service;

import com.xml.homework.model.dto.seed.product.ProductSeedRootDTO;
import com.xml.homework.model.dto.viewModels.product.ProductsInRangeVM;

import java.io.IOException;
import java.math.BigDecimal;
import java.util.List;

public interface ProductService {
    void seedProducts(ProductSeedRootDTO productSeedRootDTO) throws IOException;

    boolean productsTableIsEmpty();

    List<ProductsInRangeVM> getAllProductsInPriceRangeWithoutBuyer(BigDecimal lower, BigDecimal upper);
}
