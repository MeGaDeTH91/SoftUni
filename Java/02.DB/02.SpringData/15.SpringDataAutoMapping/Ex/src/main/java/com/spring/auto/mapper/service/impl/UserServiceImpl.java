package com.spring.auto.mapper.service.impl;

import com.spring.auto.mapper.model.dto.BaseDTO;
import com.spring.auto.mapper.model.dto.users.UserLoginDTO;
import com.spring.auto.mapper.model.dto.users.UserRegisterDTO;
import com.spring.auto.mapper.model.entity.Game;
import com.spring.auto.mapper.model.entity.User;
import com.spring.auto.mapper.repository.UserRepository;
import com.spring.auto.mapper.service.UserService;
import com.spring.auto.mapper.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.validation.ConstraintViolation;
import java.util.Collection;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;

    private User loggedInUser;

    public UserServiceImpl(UserRepository userRepository, ModelMapper modelMapper, ValidationUtil validationUtil) {
        this.userRepository = userRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        loggedInUser = null;
    }

    @Override
    public void registerUser(UserRegisterDTO userRegisterDTO) {
        boolean modelIsValid = validateRegistrationDTO(userRegisterDTO);

        if (modelIsValid) {
            var userFromBase = userRepository.findByEmail(userRegisterDTO.getEmail());

            if (userFromBase != null) {
                System.out.println("Please provide other email address");
            } else {
                var user = modelMapper.map(userRegisterDTO, User.class);

                userRepository.save(user);
                System.out.println(user.getFullName() + " was registered");
            }
        }
    }

    @Override
    public void loginUser(UserLoginDTO userLoginDTO) {
        if (this.loggedInUser != null) {
            System.out.println("There is logged in user, please logout first.");
            return;
        }

        boolean isValid = checkForValidDTO(userLoginDTO);

        if (isValid) {
            var userFromBase = userRepository
                    .findByEmailAndPassword(userLoginDTO.getEmail(), userLoginDTO.getPassword());

            if (userFromBase == null) {
                System.out.println("Please provide valid credentials.");
            } else {
                this.loggedInUser = userFromBase;
                System.out.println("Successfully logged in " + this.loggedInUser.getFullName());
            }
        }
    }

    @Override
    public void logout() {
        if (this.loggedInUser == null) {
            System.out.println("Cannot log out. No user was logged in.");
        } else {
            System.out.println("User " + this.loggedInUser.getFullName() + " successfully logged out");
            this.loggedInUser = null;
        }
    }

    @Override
    public void buyGame(Game game) {
        if (this.loggedInUser == null) {
            System.out.println("Cannot buy games. No user was logged in.");
        } else {
            this.loggedInUser.buyGame(game);
            userRepository.save(this.loggedInUser);
            System.out.println("User " + this.loggedInUser.getFullName() + " bought " + game.getTitle());
        }
    }

    @Override
    public Set<String> getUserOwnedGames() {
        if (this.loggedInUser == null) {
            return null;
        } else {
            return this.loggedInUser
                    .getGames()
                    .stream()
                    .map(Game::getTitle)
                    .collect(Collectors.toSet());
        }
    }

    public boolean loggedInAdministrator(){
        return this.loggedInUser != null && this.loggedInUser.getAdministrator();
    }

    private boolean validateRegistrationDTO(UserRegisterDTO userRegisterDTO) {
        if (userRegisterDTO.getPassword() == null || userRegisterDTO.getConfirmPassword() == null ||
                !userRegisterDTO.getPassword().equals(userRegisterDTO.getConfirmPassword())) {

            System.out.println("Passwords must match.");
            return false;
        }

        return checkForValidDTO(userRegisterDTO);
    }

    private boolean checkForValidDTO(BaseDTO userLoginDTO) {
        var violations = validationUtil.violations(userLoginDTO);
        if (!violations.isEmpty()) {
            violations
                    .stream()
                    .map(ConstraintViolation::getMessage)
                    .forEach(System.out::println);

            return false;
        }

        return true;
    }
}
