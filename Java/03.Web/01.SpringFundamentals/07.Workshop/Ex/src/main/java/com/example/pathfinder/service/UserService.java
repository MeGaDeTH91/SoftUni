package com.example.pathfinder.service;

import com.example.pathfinder.model.binding.UserLoginBindingModel;
import com.example.pathfinder.model.service.UserServiceModel;

public interface UserService {
    void registerUser(UserServiceModel userServiceModel);

    void loginUser(UserLoginBindingModel userLoginBindingModel);

    void logoutUser();
}
