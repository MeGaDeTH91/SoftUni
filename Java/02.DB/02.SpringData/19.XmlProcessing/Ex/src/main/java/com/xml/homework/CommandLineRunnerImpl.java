package com.xml.homework;

import com.xml.homework.constants.GlobalConstants;
import com.xml.homework.model.dto.seed.category.CategorySeedRootDTO;
import com.xml.homework.model.dto.seed.product.ProductSeedRootDTO;
import com.xml.homework.model.dto.seed.user.UserSeedRootDTO;
import com.xml.homework.model.dto.viewModels.category.CategoriesByProductRootVM;
import com.xml.homework.model.dto.viewModels.category.CategoriesByProductVM;
import com.xml.homework.model.dto.viewModels.product.ProductsInRangeRootVM;
import com.xml.homework.model.dto.viewModels.product.ProductsInRangeVM;
import com.xml.homework.model.dto.viewModels.user.UserSoldProductsRootVM;
import com.xml.homework.model.dto.viewModels.user.UserSoldProductsVM;
import com.xml.homework.model.dto.viewModels.user.UsersAndProductsRootVM;
import com.xml.homework.service.CategoryService;
import com.xml.homework.service.ProductService;
import com.xml.homework.service.UserService;
import com.xml.homework.util.XmlParser;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import javax.xml.bind.JAXBException;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.util.List;

@Component
public class CommandLineRunnerImpl implements CommandLineRunner {
    private static final String SEED_USERS_FILE_PATH = "users.xml";
    private static final String SEED_CATEGORIES_FILE_PATH = "categories.xml";
    private static final String SEED_PRODUCTS_FILE_PATH = "products.xml";

    private static final String RESULT_PRODUCTS_IN_RANGE_XML = "products-in-range.xml";
    private static final String RESULT_USERS_SOLD_PRODUCTS_XML = "users-sold-products.xml";
    private static final String RESULT_CATEGORIES_BY_PRODUCTS_XML = "categories-by-products.xml";
    private static final String RESULT_USERS_AND_PRODUCTS_XML = "users-and-products.xml";

    private final UserService userService;
    private final CategoryService categoryService;
    private final ProductService productService;
    private final XmlParser xmlParser;

    private final BufferedReader bufferedReader;

    public CommandLineRunnerImpl(UserService userService, CategoryService categoryService, ProductService productService, XmlParser xmlParser) {
        this.userService = userService;
        this.categoryService = categoryService;
        this.productService = productService;
        this.xmlParser = xmlParser;
        bufferedReader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public void run(String... args) throws Exception {
        seedDatabase();

        String command;
        int taskNumber;
        while (!(command = bufferedReader.readLine()).equals("end")) {
            taskNumber = Integer.parseInt(command);


            switch (taskNumber) {
                case 1:
                    productsInRange();
                    break;
                case 2:
                    usersSoldProducts();
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

    private void usersWithProducts() throws IOException, JAXBException {
        UsersAndProductsRootVM usersWithSoldProductsCount =
                userService.getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc();

        xmlParser.writeToFile(GlobalConstants.RESULT_RESOURCES_FILE_PATH + RESULT_USERS_AND_PRODUCTS_XML,
                usersWithSoldProductsCount);
    }

    private void categoriesByProductsCount() throws IOException, JAXBException {
        List<CategoriesByProductVM> categoriesWithRevenue = categoryService.getAllCategoriesOrderedByProductsNumber();

        CategoriesByProductRootVM categoriesByProductRootVM = new CategoriesByProductRootVM();
        categoriesByProductRootVM.setCategories(categoriesWithRevenue);

        xmlParser.writeToFile(GlobalConstants.RESULT_RESOURCES_FILE_PATH + RESULT_CATEGORIES_BY_PRODUCTS_XML,
                categoriesByProductRootVM);
    }

    private void usersSoldProducts() throws IOException, JAXBException {
        List<UserSoldProductsVM> usersWithSoldProducts =
                userService
                        .getAllUsersWithAtLeastOneSoldProduct();

        UserSoldProductsRootVM userSoldProductsRootVM = new UserSoldProductsRootVM();
        userSoldProductsRootVM.setUsers(usersWithSoldProducts);

        xmlParser.writeToFile(GlobalConstants.RESULT_RESOURCES_FILE_PATH + RESULT_USERS_SOLD_PRODUCTS_XML,
                userSoldProductsRootVM);
    }

    private void productsInRange() throws IOException, JAXBException {
        List<ProductsInRangeVM> productsInRange =
                productService
                        .getAllProductsInPriceRangeWithoutBuyer(BigDecimal.valueOf(500), BigDecimal.valueOf(1000));

        ProductsInRangeRootVM productsRoot = new ProductsInRangeRootVM();
        productsRoot.setProducts(productsInRange);
        xmlParser.writeToFile(GlobalConstants.RESULT_RESOURCES_FILE_PATH + RESULT_PRODUCTS_IN_RANGE_XML,
                productsRoot);
    }

    private void seedDatabase() throws IOException, JAXBException {
        if (userService.usersTableIsEmpty() && categoryService.categoriesTableIsEmpty() &&
                productService.productsTableIsEmpty()) {
            seedUsers();
            seedCategories();
            seedProducts();
        }
    }

    private void seedUsers() throws IOException, JAXBException {
        var users = xmlParser.readFromFile(GlobalConstants.SEED_RESOURCES_FILE_PATH + SEED_USERS_FILE_PATH,
                        UserSeedRootDTO.class);
        userService.seedUsers(users);
    }

    private void seedCategories() throws IOException, JAXBException {
        var categories = xmlParser.readFromFile(GlobalConstants.SEED_RESOURCES_FILE_PATH + SEED_CATEGORIES_FILE_PATH,
                CategorySeedRootDTO.class);
        categoryService.seedCategories(categories);
    }

    private void seedProducts() throws IOException, JAXBException {
        var products = xmlParser.readFromFile(GlobalConstants.SEED_RESOURCES_FILE_PATH + SEED_PRODUCTS_FILE_PATH,
                ProductSeedRootDTO.class);
        productService.seedProducts(products);
    }
}
