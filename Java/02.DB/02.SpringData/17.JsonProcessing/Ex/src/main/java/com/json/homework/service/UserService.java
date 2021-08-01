package com.json.homework.service;

import com.json.homework.model.entity.User;
import com.json.homework.model.viewModels.UserFirstNameLastNameAgeSellsVM;
import com.json.homework.model.viewModels.UserWithSoldProductsVM;
import com.json.homework.model.viewModels.UsersWithSoldProductsCountVM;

import java.io.IOException;
import java.util.List;

public interface UserService {
    void seedUsers() throws IOException;

    User getRandomSeller();

    User getRandomBuyerDifferentFromSeller(long id);

    List<UserWithSoldProductsVM> getAllUsersWithAtLeastOneSoldProduct();

    UsersWithSoldProductsCountVM getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc();
}
