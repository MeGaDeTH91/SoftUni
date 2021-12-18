package com.demo.examprep.service;

import com.demo.examprep.model.entity.User;
import com.demo.examprep.model.service.UserServiceModel;
import com.demo.examprep.model.view.UserViewModel;

import java.util.List;

public interface UserService {
    UserServiceModel registerUser(UserServiceModel map);

    UserServiceModel loginUser(String username, String password);

    boolean emailAlreadyExists(String email);

    boolean usernameAlreadyExists(String email);

    User getUserById(Long id);

    List<UserViewModel> getUsersByOrdersCountDesc();
}
