package com.demo.examprep.service.impl;

import com.demo.examprep.model.entity.User;
import com.demo.examprep.model.service.UserServiceModel;
import com.demo.examprep.model.view.UserViewModel;
import com.demo.examprep.repository.UserRepository;
import com.demo.examprep.service.UserService;
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
    public List<UserViewModel> getUsersByOrdersCountDesc() {
        return userRepository
                .findAllByUsersOrderByOrderCountDesc()
                .stream()
                .map(user -> {
                    UserViewModel userViewModel = new UserViewModel();
                    userViewModel.setUsername(user.getUsername());
                    userViewModel.setOrdersCount(user.getOrders().size());

                    return userViewModel;
                })
                .collect(Collectors.toList());
    }
}
