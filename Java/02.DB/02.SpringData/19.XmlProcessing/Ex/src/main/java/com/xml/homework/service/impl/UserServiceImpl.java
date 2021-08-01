package com.xml.homework.service.impl;

import com.xml.homework.model.dto.seed.user.UserSeedRootDTO;
import com.xml.homework.model.dto.viewModels.product.UsersAndProductsProductNameAndPriceVM;
import com.xml.homework.model.dto.viewModels.product.UsersAndProductsSoldProductsVM;
import com.xml.homework.model.dto.viewModels.user.UserAndProductsFirstNameLastNameAgeSellsVM;
import com.xml.homework.model.dto.viewModels.user.UsersAndProductsRootVM;
import com.xml.homework.model.dto.viewModels.user.UserSoldProductsVM;
import com.xml.homework.model.entity.User;
import com.xml.homework.repository.UserRepository;
import com.xml.homework.service.UserService;
import com.xml.homework.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {


    private final UserRepository userRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;

    public UserServiceImpl(UserRepository userRepository, ModelMapper modelMapper, ValidationUtil validationUtil) {
        this.userRepository = userRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
    }

    @Override
    public void seedUsers(UserSeedRootDTO userSeedRootDTO) {
        userSeedRootDTO.getUsers()
                .stream()
                .filter(validationUtil::isValid)
                .map(userDTO -> modelMapper.map(userDTO, User.class))
                .forEach(userRepository::save);
    }

    @Override
    public boolean usersTableIsEmpty() {
        return this.userRepository.count() == 0;
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
    public List<UserSoldProductsVM> getAllUsersWithAtLeastOneSoldProduct() {
        return userRepository.findAllWithAtLeastOneSoldProductOrderByNameAsc()
                .stream()
                .map(user -> {
                    UserSoldProductsVM userWithSoldProductsVM = modelMapper.map(user, UserSoldProductsVM.class);

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
    public UsersAndProductsRootVM getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc() {
        var mappedUsers = userRepository.findAllUsersWithAtLeastOneSoldProductOrderByProductsNumDesc()
                .stream()
                .map(this::mapUser)
                .collect(Collectors.toList());

        UsersAndProductsRootVM usersWithCount = new UsersAndProductsRootVM();
        usersWithCount.setUsers(mappedUsers);
        usersWithCount.setUsersCount(mappedUsers.size());

        return usersWithCount;
    }

    private UserAndProductsFirstNameLastNameAgeSellsVM mapUser(User user) {
        UserAndProductsFirstNameLastNameAgeSellsVM mappedUser = new UserAndProductsFirstNameLastNameAgeSellsVM();

        mappedUser.setFirstName(user.getFirstName());
        mappedUser.setLastName(user.getLastName());
        mappedUser.setAge(user.getAge());

        mapUserSoldProducts(mappedUser, user);

        return mappedUser;
    }

    private void mapUserSoldProducts(UserAndProductsFirstNameLastNameAgeSellsVM mappedUser, User user) {
        UsersAndProductsSoldProductsVM soldProductsVM = new UsersAndProductsSoldProductsVM();

        soldProductsVM.setCount(user.getSoldProducts().size());
        List<UsersAndProductsProductNameAndPriceVM> mappedProducts = user.getSoldProducts()
                .stream()
                .map(product -> modelMapper.map(product, UsersAndProductsProductNameAndPriceVM.class))
                .collect(Collectors.toList());

        soldProductsVM.setProducts(mappedProducts);

        mappedUser.setSoldProducts(soldProductsVM);
    }
}
