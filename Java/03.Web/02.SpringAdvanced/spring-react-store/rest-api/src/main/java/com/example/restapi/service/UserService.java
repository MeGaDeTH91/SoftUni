package com.example.restapi.service;

import com.example.restapi.model.service.UserServiceModel;
import org.springframework.security.core.userdetails.UserDetailsService;

import java.util.List;

public interface UserService extends UserDetailsService {

    UserServiceModel register(UserServiceModel userServiceModel);

    boolean existsByUsername(String username);

    boolean existsById(Long id);

    UserServiceModel getById(Long id);

    UserServiceModel getByUsername(String username);

    UserServiceModel update(UserServiceModel userServiceModel);

    List<UserServiceModel> getAllUsers();

    UserServiceModel changeAdminStatus(Long id);

    UserServiceModel changeActivityStatus(Long id);
}
