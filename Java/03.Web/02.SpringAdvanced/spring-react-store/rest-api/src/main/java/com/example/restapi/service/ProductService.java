package com.example.restapi.service;

import com.example.restapi.model.service.ProductUpdateServiceModel;
import com.example.restapi.model.service.ProductServiceModel;

import java.util.List;

public interface ProductService {
    List<ProductServiceModel> getAll();

    boolean existsByTitle(String title);

    boolean existsById(Long id);

    ProductServiceModel create(ProductServiceModel productServiceModel);

    ProductServiceModel update(ProductUpdateServiceModel productServiceModel);

    ProductServiceModel get(Long id);

    void delete(Long id);

    void reduceQuantity(Long id);
}
