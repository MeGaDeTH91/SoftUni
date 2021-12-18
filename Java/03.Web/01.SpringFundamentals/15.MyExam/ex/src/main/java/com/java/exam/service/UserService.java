package com.java.exam.service;


import com.java.exam.model.entity.User;
import com.java.exam.model.service.UserServiceModel;
import com.java.exam.model.view.UserViewModel;

public interface UserService {
    UserServiceModel registerUser(UserServiceModel map);

    UserServiceModel loginUser(String username, String password);

    boolean emailAlreadyExists(String email);

    boolean usernameAlreadyExists(String email);

    User getUserById(Long id);

    UserViewModel getUserViewModelById(Long id);
}
