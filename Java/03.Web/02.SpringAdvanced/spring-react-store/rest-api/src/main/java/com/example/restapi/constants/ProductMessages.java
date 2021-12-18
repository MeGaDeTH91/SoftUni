package com.example.restapi.constants;

public class ProductMessages {
    public static final String ERROR_GETTING_ALL_PRODUCTS = "Error occurred while getting all products!";
    public static final String CREATION_NOT_SUCCESSFUL = "Product creation was not successful.";
    public static final String UPDATE_NOT_SUCCESSFUL = "Product update was not successful.";
    public static final String PRODUCT_ALREADY_EXISTS = "Product already exists.";
    public static final String PRODUCT_DOES_NOT_EXISTS = "Product does not exist.";
    public static final String PRODUCT_DELETED_SUCCESSFULLY = "Successfully removed product!";

    // Binding
    public static final String TITLE_VALIDATION = "Title should be between 5 and 30 characters long.";
    public static final String DESCRIPTION_VALIDATION = "Description should be between 10 and 250 characters long.";
    public static final String PRICE_VALIDATION = "Price should be positive number.";
    public static final String QUANTITY_VALIDATION = "Price should not be negative number.";
    public static final String IMAGE_URL_VALIDATION = "Enter valid URL.";
    public static final String CATEGORY_VALIDATION = "Category cannot be empty.";
}
