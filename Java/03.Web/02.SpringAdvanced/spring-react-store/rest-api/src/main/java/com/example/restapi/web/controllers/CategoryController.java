package com.example.restapi.web.controllers;

import com.example.restapi.constants.CategoryMessages;
import com.example.restapi.model.binding.CategoryBindingModel;
import com.example.restapi.model.service.CategoryServiceModel;
import com.example.restapi.model.service.CategoryUpdateServiceModel;
import com.example.restapi.model.view.CategoryDetailsViewModel;
import com.example.restapi.model.view.CategoryListViewModel;
import com.example.restapi.service.CategoryService;
import com.example.restapi.util.JSONResponse;
import org.modelmapper.ModelMapper;
import org.springframework.context.support.DefaultMessageSourceResolvable;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.BindingResult;
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
@RequestMapping("/categories")
public class CategoryController {
    private final CategoryService categoryService;
    private final ModelMapper modelMapper;

    public CategoryController(CategoryService categoryService, ModelMapper modelMapper) {
        this.categoryService = categoryService;
        this.modelMapper = modelMapper;
    }

    @GetMapping(value = "/all", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<?> all() {
        List<CategoryServiceModel> categoriesServiceList = categoryService.getAll();

        if (categoriesServiceList == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(CategoryMessages.ERROR_GETTING_ALL_CATEGORIES));
        }

        List<CategoryListViewModel> categories = categoriesServiceList
                .stream()
                .map(prod -> modelMapper.map(prod, CategoryListViewModel.class))
                .collect(Collectors.toList());

        return ResponseEntity.ok(categories);
    }

    @GetMapping(value = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<?> get(@PathVariable Long id) {
        CategoryServiceModel category = categoryService.get(id);

        if (category == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(CategoryMessages.ERROR_GETTING_ALL_CATEGORIES));
        }

        return ResponseEntity.ok(modelMapper.map(category, CategoryDetailsViewModel.class));
    }

    @PostMapping(value = "/create",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> create(@Valid @RequestBody CategoryBindingModel categoryBindingModel,
                                         BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        if (categoryService.exists(categoryBindingModel.getTitle())) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(CategoryMessages.CATEGORY_ALREADY_EXISTS));
        }

        CategoryServiceModel category = this.categoryService.create(modelMapper.map(categoryBindingModel, CategoryServiceModel.class));

        if (category == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(CategoryMessages.CREATION_NOT_SUCCESSFUL));
        }

        return ResponseEntity.ok(category);
    }

    @PutMapping(value = "/{id}",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> update(@PathVariable Long id, @Valid @RequestBody CategoryBindingModel categoryBindingModel,
                                         BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        CategoryServiceModel categoryServiceModel = categoryService.get(id);
        if (categoryServiceModel == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(CategoryMessages.CATEGORY_DOES_NOT_EXISTS));
        }
        modelMapper.map(categoryBindingModel, categoryServiceModel);

        CategoryServiceModel category = categoryService.update(modelMapper.map(categoryServiceModel, CategoryUpdateServiceModel.class));

        if (category == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(CategoryMessages.UPDATE_NOT_SUCCESSFUL));
        }
        CategoryListViewModel categoryListViewModel = modelMapper.map(category, CategoryListViewModel.class);

        return ResponseEntity.ok(categoryListViewModel);
    }
}
