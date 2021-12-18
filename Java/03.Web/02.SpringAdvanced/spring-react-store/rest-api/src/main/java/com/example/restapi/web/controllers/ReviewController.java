package com.example.restapi.web.controllers;

import com.example.restapi.constants.ProductMessages;
import com.example.restapi.constants.ReviewMessages;
import com.example.restapi.constants.UserMessages;
import com.example.restapi.model.binding.ReviewBindingModel;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.model.service.ReviewServiceModel;
import com.example.restapi.model.service.UserServiceModel;
import com.example.restapi.model.view.ProductReviewsViewModel;
import com.example.restapi.service.ProductService;
import com.example.restapi.service.ReviewService;
import com.example.restapi.service.UserService;
import com.example.restapi.util.JSONResponse;
import org.modelmapper.ModelMapper;
import org.springframework.context.support.DefaultMessageSourceResolvable;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;

@RestController
@RequestMapping("/reviews")
public class ReviewController {
    private final ReviewService reviewService;
    private final UserService userService;
    private final ProductService productService;
    private final ModelMapper modelMapper;

    public ReviewController(ReviewService reviewService, UserService userService, ProductService productService,
                            ModelMapper modelMapper) {
        this.reviewService = reviewService;
        this.userService = userService;
        this.productService = productService;
        this.modelMapper = modelMapper;
    }

    @PostMapping(value = "/create",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('USER')")
    public ResponseEntity<Object> create(@Valid @RequestBody ReviewBindingModel reviewBindingModel, BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        if (!userService.existsById(reviewBindingModel.getReviewer())) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_DOES_NOT_EXIST));
        }
        if (!productService.existsById(reviewBindingModel.getProduct())) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(ProductMessages.PRODUCT_DOES_NOT_EXISTS));
        }

        ProductServiceModel product = productService.get(reviewBindingModel.getProduct());
        UserServiceModel user = userService.getById(reviewBindingModel.getReviewer());
        ReviewServiceModel reviewServiceModel = modelMapper.map(reviewBindingModel, ReviewServiceModel.class);
        reviewServiceModel.setProduct(product);
        reviewServiceModel.setReviewer(user);

        ReviewServiceModel review = reviewService.create(reviewServiceModel);

        if (review == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(ReviewMessages.CREATION_NOT_SUCCESSFUL));
        }

        return ResponseEntity.ok(modelMapper.map(review, ProductReviewsViewModel.class));
    }
}
