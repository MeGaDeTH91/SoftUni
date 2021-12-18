package com.example.pathfinder.service.impl;

import com.example.pathfinder.model.binding.UserLoginBindingModel;
import com.example.pathfinder.model.entity.User;
import com.example.pathfinder.model.enums.LevelEnum;
import com.example.pathfinder.model.enums.RoleNameEnum;
import com.example.pathfinder.model.service.UserServiceModel;
import com.example.pathfinder.repository.UserRepository;
import com.example.pathfinder.service.UserService;
import com.example.pathfinder.util.CurrentUser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

@Service
public class UserServiceImpl implements UserService {
    private final ModelMapper modelMapper;
    private final UserRepository userRepository;
    private final CurrentUser currentUser;

    public UserServiceImpl(ModelMapper modelMapper, UserRepository userRepository, CurrentUser currentUser) {
        this.modelMapper = modelMapper;
        this.userRepository = userRepository;
        this.currentUser = currentUser;
    }

    @Override
    public void registerUser(UserServiceModel userServiceModel) {
        User user = modelMapper.map(userServiceModel, User.class);
        user.setLevel(LevelEnum.BEGINNER);

        userRepository.save(user);
    }

    @Override
    public void loginUser(UserLoginBindingModel userLoginBindingModel) {
        User user = userRepository
                .findAllByUsernameAndPassword(userLoginBindingModel.getUsername(), userLoginBindingModel.getPassword())
                .orElse(null);

        if (user != null) {
            currentUser.setId(user.getId());
            currentUser.setUsername(user.getUsername());
            currentUser.setAdministrator(currentUserIsAdministrator(user));
        }
    }

    @Override
    public void logoutUser() {
        currentUser.setId(null);
        currentUser.setUsername(null);
        currentUser.setAdministrator(false);
    }

    private boolean currentUserIsAdministrator(User user){
        return user.getRoles().stream().anyMatch(role -> role.getRole().equals(RoleNameEnum.ADMIN));
    }
}
