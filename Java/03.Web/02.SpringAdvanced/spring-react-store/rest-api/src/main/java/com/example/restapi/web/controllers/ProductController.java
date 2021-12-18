package com.example.restapi.web.controllers;

import com.example.restapi.constants.ProductMessages;
import com.example.restapi.model.binding.ProductBindingModel;
import com.example.restapi.model.service.CategoryServiceModel;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.model.service.ProductUpdateServiceModel;
import com.example.restapi.model.view.ProductDetailsViewModel;
import com.example.restapi.service.ProductService;
import com.example.restapi.util.JSONResponse;
import org.modelmapper.ModelMapper;
import org.springframework.context.support.DefaultMessageSourceResolvable;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/products")
public class ProductController {
    private final ProductService productService;
    private final ModelMapper modelMapper;

    public ProductController(ProductService productService, ModelMapper modelMapper) {
        this.productService = productService;
        this.modelMapper = modelMapper;
    }

    @GetMapping(value = "/all", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<?> all() {
        List<ProductServiceModel> productsServiceList = productService.getAll();

        if (productsServiceList == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(ProductMessages.ERROR_GETTING_ALL_PRODUCTS));
        }

        List<ProductDetailsViewModel> products = productsServiceList
                .stream()
                .map(prod -> modelMapper.map(prod, ProductDetailsViewModel.class))
                .collect(Collectors.toList());

        return ResponseEntity.ok(products);
    }

    @PostMapping(value = "/create",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> create(@Valid @RequestBody ProductBindingModel productBindingModel,
                                         BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        if (productService.existsByTitle(productBindingModel.getTitle())) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(ProductMessages.PRODUCT_ALREADY_EXISTS));
        }
        ProductServiceModel productServiceModel = modelMapper.map(productBindingModel, ProductServiceModel.class);
        productServiceModel.setCategory(new CategoryServiceModel(productBindingModel.getCategory()));

        ProductServiceModel product = this.productService.create(productServiceModel);

        if (product == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(ProductMessages.CREATION_NOT_SUCCESSFUL));
        }

        return ResponseEntity.ok(product);
    }

    @GetMapping(value = "/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Object> get(@PathVariable Long id) {

        ProductServiceModel productServiceModel = productService.get(id);
        if (productServiceModel == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(ProductMessages.PRODUCT_DOES_NOT_EXISTS));
        }
        return ResponseEntity.ok(modelMapper.map(productServiceModel, ProductDetailsViewModel.class));
    }

    @PutMapping(value = "/{id}",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> update(@PathVariable Long id, @Valid @RequestBody ProductBindingModel productBindingModel,
                                         BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(com.example.restapi.util.JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        ProductServiceModel productServiceModel = productService.get(id);
        if (productServiceModel == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(ProductMessages.PRODUCT_DOES_NOT_EXISTS));
        }
        modelMapper.map(productBindingModel, productServiceModel);

        ProductServiceModel product = productService.update(modelMapper.map(productServiceModel, ProductUpdateServiceModel.class));

        if (product == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(ProductMessages.UPDATE_NOT_SUCCESSFUL));
        }
        ProductDetailsViewModel productViewModel = modelMapper.map(product, ProductDetailsViewModel.class);

        return ResponseEntity.ok(productViewModel);
    }

    @DeleteMapping(value = "/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> delete(@PathVariable Long id) {
        if (!productService.existsById(id)) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(ProductMessages.PRODUCT_DOES_NOT_EXISTS));
        }

        productService.delete(id);

        return ResponseEntity.ok(JSONResponse.jsonFromString(ProductMessages.PRODUCT_DELETED_SUCCESSFULLY));
    }
}
