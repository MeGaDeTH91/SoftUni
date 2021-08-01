package com.spring.auto.mapper.service;

import com.spring.auto.mapper.model.dto.users.UserLoginDTO;
import com.spring.auto.mapper.model.dto.users.UserRegisterDTO;
import com.spring.auto.mapper.model.entity.Game;

import java.util.Set;


public interface UserService {
    void registerUser(UserRegisterDTO userRegisterDTO);

    void loginUser(UserLoginDTO userLoginDTO);

    void logout();

    void buyGame(Game game);

    Set<String> getUserOwnedGames();

    boolean loggedInAdministrator();
}
