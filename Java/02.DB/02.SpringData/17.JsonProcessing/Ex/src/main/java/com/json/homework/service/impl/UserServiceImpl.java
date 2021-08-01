package com.json.homework.service.impl;

import com.google.gson.Gson;
import com.json.homework.constants.GlobalConstants;
import com.json.homework.model.dto.UserDTO;
import com.json.homework.model.entity.User;
import com.json.homework.model.viewModels.ProductNameAndPriceVM;
import com.json.homework.model.viewModels.SoldProductsVM;
import com.json.homework.model.viewModels.UserFirstNameLastNameAgeSellsVM;
import com.json.homework.model.viewModels.UserWithSoldProductsVM;
import com.json.homework.model.viewModels.UsersWithSoldProductsCountVM;
import com.json.homework.repository.UserRepository;
import com.json.homework.service.UserService;
import com.json.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {
    private static final String USERS_FILE_PATH = "users.json";

    private final UserRepository userRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public UserServiceImpl(UserRepository userRepository, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.userRepository = userRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public void seedUsers() throws IOException {
        if (userRepository.count() < 1) {
            Arrays.stream(gson
                    .fromJson(Files.readString(Path.of(GlobalConstants.SEED_RESOURCES_FILE_PATH + USERS_FILE_PATH)),
                            UserDTO[].class))
                    .filter(validationUtil::isValid)
                    .map(userDTO -> modelMapper.map(userDTO, User.class))
                    .forEach(userRepository::save);
        }
    }

    @Override
    public User getRandomSeller() {
        long usersAllCount = userRepository.count() + 1;

        long randomUserId = ThreadLocalRandom
                .current()
                .nextLong(1, usersAllCount);

        return userRepository.findById(randomUserId).orElse(null);
    }

    @Override
    public User getRandomBuyerDifferentFromSeller(long id) {
        long usersAllCount = userRepository.count() + 1;

        long randomUserId = ThreadLocalRandom
                .current()
                .nextLong(1, usersAllCount);

        while (randomUserId == id) {
            randomUserId = ThreadLocalRandom
                .current()
                    .nextLong(1, usersAllCount);
        }

        return userRepository.findById(randomUserId).orElse(null);
    }

    @Override
    public List<UserWithSoldProductsVM> getAllUsersWithAtLeastOneSoldProduct() {
        return userRepository.findAllWithAtLeastOneSoldProductOrderByNameAsc()
                .stream()
                .map(user -> {
                    UserWithSoldProductsVM userWithSoldProductsVM = modelMapper.map(user, UserWithSoldProductsVM.class);

                    userWithSoldProductsVM
                            .setSoldProducts(userWithSoldProductsVM
                                    .getSoldProducts()
                                    .stream()
                                    .filter(validationUtil::isValid)
                            .collect(Collectors.toList()));

                    return userWithSoldProductsVM;
                })
                .collect(Collectors.toList());
    }

    @Override
    public UsersWithSoldProductsCountVM getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc() {
        var mappedUsers = userRepository.findAllUsersWithAtLeastOneSoldProductOrderByProductsNumDesc()
                .stream()
                .map(this::mapUser)
                .collect(Collectors.toList());

        UsersWithSoldProductsCountVM usersWithCount = new UsersWithSoldProductsCountVM();
        usersWithCount.setUsers(mappedUsers);
        usersWithCount.setUsersCount(mappedUsers.size());


        return usersWithCount;
    }

    private UserFirstNameLastNameAgeSellsVM mapUser(User user) {
        UserFirstNameLastNameAgeSellsVM mappedUser = new UserFirstNameLastNameAgeSellsVM();

        mappedUser.setFirstName(user.getFirstName());
        mappedUser.setLastName(user.getLastName());
        mappedUser.setAge(user.getAge());

        mapUserSoldProducts(mappedUser, user);

        return mappedUser;
    }

    private void mapUserSoldProducts(UserFirstNameLastNameAgeSellsVM mappedUser, User user) {
        SoldProductsVM soldProductsVM = new SoldProductsVM();

        soldProductsVM.setCount(user.getSoldProducts().size());
        List<ProductNameAndPriceVM> mappedProducts = user.getSoldProducts()
                .stream()
                .map(product -> modelMapper.map(product, ProductNameAndPriceVM.class))
                .collect(Collectors.toList());

        soldProductsVM.setProducts(mappedProducts);

        mappedUser.setSoldProducts(soldProductsVM);
    }
}
