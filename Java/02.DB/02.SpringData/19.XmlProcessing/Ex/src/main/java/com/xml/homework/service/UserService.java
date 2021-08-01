package com.xml.homework.service;

import com.xml.homework.model.dto.seed.user.UserSeedRootDTO;
import com.xml.homework.model.entity.User;
import com.xml.homework.model.dto.viewModels.user.UserSoldProductsVM;
import com.xml.homework.model.dto.viewModels.user.UsersAndProductsRootVM;

import java.io.IOException;
import java.util.List;

public interface UserService {
    void seedUsers(UserSeedRootDTO userSeedRootDTO) throws IOException;

    boolean usersTableIsEmpty();

    User getRandomSeller();

    User getRandomBuyerDifferentFromSeller(long id);

    List<UserSoldProductsVM> getAllUsersWithAtLeastOneSoldProduct();

    UsersAndProductsRootVM getAllUsersWithAtLeastOneSoldProductOrderedByProductsCountDesc();
}
