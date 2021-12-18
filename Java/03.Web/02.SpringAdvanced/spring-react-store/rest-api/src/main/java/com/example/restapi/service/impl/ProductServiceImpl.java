package com.example.restapi.service.impl;

import com.example.restapi.model.entity.Product;
import com.example.restapi.model.service.ProductUpdateServiceModel;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.model.service.ReviewServiceModel;
import com.example.restapi.repository.ProductRepository;
import com.example.restapi.service.ProductService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductServiceImpl implements ProductService {
    private final ProductRepository productRepository;
    private final ModelMapper modelMapper;

    public ProductServiceImpl(ProductRepository productRepository, ModelMapper modelMapper) {
        this.productRepository = productRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public List<ProductServiceModel> getAll() {
        return productRepository
                .findAll()
                .stream()
                .map(product -> modelMapper.map(product, ProductServiceModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public boolean existsByTitle(String title) {
        return productRepository.existsByTitle(title);
    }

    @Override
    public boolean existsById(Long id) {
        return productRepository.existsById(id);
    }

    @Override
    public ProductServiceModel create(ProductServiceModel productServiceModel) {
        Product product = this.modelMapper.map(productServiceModel, Product.class);

        return this.modelMapper.map(this.productRepository.saveAndFlush(product), ProductServiceModel.class);
    }

    @Override
    public ProductServiceModel update(ProductUpdateServiceModel productServiceModel) {
        Product product = productRepository.findById(productServiceModel.getId()).orElse(null);
        if (product == null) {
            return null;
        }
        modelMapper.map(productServiceModel, product);
        productRepository.save(product);

        return modelMapper.map(product, ProductServiceModel.class);
    }

    @Override
    public ProductServiceModel get(Long id) {
        Product repoProduct = productRepository.findById(id).orElse(null);
        if (repoProduct == null) {
            return null;
        }
        repoProduct.getCarts().clear();
        ProductServiceModel mappedProduct = modelMapper.map(repoProduct, ProductServiceModel.class);
        if (mappedProduct.getReviews() == null && repoProduct.getReviews() != null) {
            mappedProduct.setReviews(repoProduct.getReviews()
                    .stream().map(review -> modelMapper.map(review, ReviewServiceModel.class))
                    .collect(Collectors.toSet()));
        }
        return mappedProduct;
    }

    @Override
    public void delete(Long id) {
        Product repoProduct = productRepository.findById(id).orElse(null);
        if (repoProduct == null || repoProduct.getCarts() == null) {
            return;
        }
        repoProduct.getCarts().clear();
        productRepository.save(repoProduct);
        productRepository.deleteById(id);
    }

    @Override
    public void reduceQuantity(Long id) {
        Product repoProduct = productRepository.findById(id).orElse(null);
        if (repoProduct == null || repoProduct.getCarts() == null) {
            return;
        }

        repoProduct.setQuantity(repoProduct.getQuantity() - 1);
        productRepository.save(repoProduct);
    }
}
