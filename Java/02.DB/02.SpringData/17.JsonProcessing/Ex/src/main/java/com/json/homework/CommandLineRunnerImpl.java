package com.json.homework;

import com.google.gson.Gson;
import com.json.homework.constants.GlobalConstants;
import com.json.homework.model.viewModels.CategoryWithRevenueVM;
import com.json.homework.model.viewModels.ProductsInRangeVM;
import com.json.homework.model.viewModels.UserWithSoldProductsVM;
import com.json.homework.model.viewModels.UsersWithSoldProductsCountVM;
import com.json.homework.service.CategoryService;
import com.json.homework.service.ProductService;
import com.json.homework.service.UserService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Collections;
import java.util.List;

@Component
public class CommandLineRunnerImpl implements CommandLineRunner {
    private static final String PRODUCTS_IN_RANGE_JSON = "products-in-range.json";
    private static final String USERS_WITH_SOLD_PRODUCT_JSON = "users-sold-products.json";
    private static final String CATEGORIES_WITH_PRODUCT_REVENUE_JSON = "categories-by-products.json";
    private static final String USERS_AND_PRODUCTS_JSON = "users-and-products.json";

    private final UserService userService;
    private final CategoryService categoryService;
    private final ProductService productService;
    private final Gson gson;

    private final BufferedReader bufferedReader;

    public CommandLineRunnerImpl(UserService userService, CategoryService categoryService, ProductService productService, Gson gson) {
        this.userService = userService;
        this.categoryService = categoryService;
        this.productService = productService;
        this.gson = gson;
        bufferedReader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public void run(String... args) throws Exception {
        seedDatabase();

        String command;
        int taskNumber;
        while(!(command = bufferedReader.readLine()).equals("end")) {
            taskNumber = Integer.parseInt(command);


            switch (taskNumber){
                case 1:
                    productsInRange();
                    break;
                case 2:
                    usersWithSuccessfullySoldProducts();
                    break;
                case 3:
                    categoriesByProductsCount();
                    break;
                case 4:
                    usersWithProducts();
                    break;
                default:
                    System.out.println("Please provide valid task number, 'end' stops the program");
                    break;
            }
        }
    }

    private void usersWithProducts() throws IOException {
        UsersWithSoldProductsCountVM usersWithSoldProductsCount =
                userService.getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc();

        String usersContent = gson.toJson(usersWithSoldProductsCount);

        writeToFile(USERS_AND_PRODUCTS_JSON, usersContent);
    }

    private void categoriesByProductsCount() throws IOException {
        List<CategoryWithRevenueVM> categoriesWithRevenue = categoryService.getAllCategoriesOrderedByProductsNumber();

        String categoriesContent = gson.toJson(categoriesWithRevenue);

        writeToFile(CATEGORIES_WITH_PRODUCT_REVENUE_JSON, categoriesContent);
    }

    private void usersWithSuccessfullySoldProducts() throws IOException {
        List<UserWithSoldProductsVM> usersWithSoldProducts =
                userService
                        .getAllUsersWithAtLeastOneSoldProduct();

        String usersContent = gson.toJson(usersWithSoldProducts);

        writeToFile(USERS_WITH_SOLD_PRODUCT_JSON, usersContent);
    }

    private void productsInRange() throws IOException {
        List<ProductsInRangeVM> productsInRange =
                productService
                        .getAllProductsInPriceRangeWithoutBuyer(BigDecimal.valueOf(500), BigDecimal.valueOf(1000));

        String productsContent = gson.toJson(productsInRange);

        writeToFile(PRODUCTS_IN_RANGE_JSON, productsContent);
    }

    private void writeToFile(String fileName, String productsContent) throws IOException {
        Files
                .write(Path.of(GlobalConstants.RESULT_RESOURCES_FILE_PATH + fileName), Collections.singleton(productsContent));
    }

    private void seedDatabase() throws IOException {
        userService.seedUsers();
        categoryService.seedCategories();
        productService.seedProducts();
    }
}
