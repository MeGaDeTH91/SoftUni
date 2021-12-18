package com.java.exam.service.impl;

import com.java.exam.model.entity.User;
import com.java.exam.model.service.UserServiceModel;
import com.java.exam.model.view.ShipViewModel;
import com.java.exam.model.view.UserViewModel;
import com.java.exam.repository.UserRepository;
import com.java.exam.service.UserService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;
    private final ModelMapper modelMapper;

    public UserServiceImpl(UserRepository userRepository, ModelMapper modelMapper) {
        this.userRepository = userRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public UserServiceModel registerUser(UserServiceModel userServiceModel) {
        User user = modelMapper.map(userServiceModel, User.class);

        return modelMapper.map(userRepository.save(user), UserServiceModel.class);
    }

    @Override
    public UserServiceModel loginUser(String username, String password) {
        User user = userRepository
                .findByUsernameAndPassword(username, password)
                .orElse(null);

        if (user == null) {
            return null;
        }

        return modelMapper.map(user, UserServiceModel.class);
    }

    @Override
    public boolean emailAlreadyExists(String email) {
        return userRepository.existsByEmail(email);
    }

    @Override
    public boolean usernameAlreadyExists(String username) {
        return userRepository.existsByUsername(username);
    }

    @Override
    public User getUserById(Long id) {
        return userRepository.findById(id).orElse(null);
    }

    @Override
    public UserViewModel getUserViewModelById(Long id) {
        User user = getUserById(id);

        if (user == null) {
            return null;
        }

        UserViewModel userViewModel = new UserViewModel();
        userViewModel.setUsername(user.getUsername());
        List<ShipViewModel> ships = user.getShips().stream().map(
                ship -> modelMapper.map(ship, ShipViewModel.class)
        ).collect(Collectors.toList());

        userViewModel.setShips(ships);

        return userViewModel;
    }
}
