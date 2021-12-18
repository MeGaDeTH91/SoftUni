package com.example.restapi.web.controllers;

import com.example.restapi.constants.RolesData;
import com.example.restapi.constants.UserMessages;
import com.example.restapi.model.binding.UserRegisterBindingModel;
import com.example.restapi.model.binding.UserUpdateBindingModel;
import com.example.restapi.model.service.ShoppingCartServiceModel;
import com.example.restapi.model.service.UserServiceModel;
import com.example.restapi.model.view.UserDetailsViewModel;
import com.example.restapi.model.view.UserListViewModel;
import com.example.restapi.service.ShoppingCartService;
import com.example.restapi.service.UserService;
import com.example.restapi.util.JSONResponse;
import org.modelmapper.ModelMapper;
import org.springframework.context.support.DefaultMessageSourceResolvable;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/users")
public class UserController {
    private final UserService userService;
    private final ShoppingCartService shoppingCartService;
    private final ModelMapper modelMapper;

    public UserController(UserService userService, ShoppingCartService shoppingCartService, ModelMapper modelMapper) {
        this.userService = userService;
        this.shoppingCartService = shoppingCartService;
        this.modelMapper = modelMapper;
    }

    @GetMapping(value = "/all",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> getAll() {
        List<UserServiceModel> dbUsers = userService.getAllUsers();
        if (dbUsers == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.NO_USERS_DATA));
        }

        List<UserListViewModel> users = dbUsers
                .stream()
                .map(currUser -> {
                    UserListViewModel mappedUser = modelMapper.map(currUser, UserListViewModel.class);
                    mapUserFields(currUser, mappedUser);

                    return mappedUser;
                })
                .collect(Collectors.toList());

        return ResponseEntity.ok(users);
    }

    @PutMapping(value = "/change-role/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ROOT')")
    public ResponseEntity<Object> changeRole(@PathVariable Long id) {
        UserServiceModel user = userService.getById(id);
        if (user == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_DOES_NOT_EXIST));
        }

        user = userService.changeAdminStatus(user.getId());

        return ResponseEntity.ok(modelMapper.map(user, UserDetailsViewModel.class));
    }

    @PutMapping(value = "/change-status/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<Object> changeStatus(@PathVariable Long id) {
        UserServiceModel user = userService.getById(id);
        if (user == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_DOES_NOT_EXIST));
        }

        user = userService.changeActivityStatus(user.getId());

        return ResponseEntity.ok(modelMapper.map(user, UserDetailsViewModel.class));
    }

    @GetMapping(value = "/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('USER')")
    public ResponseEntity<Object> get(@PathVariable Long id) {
        UserServiceModel userServiceModel = userService.getById(id);
        if (userServiceModel == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_DOES_NOT_EXIST));
        }
        return ResponseEntity.ok(modelMapper.map(userServiceModel, UserDetailsViewModel.class));
    }

    @PutMapping(value = "/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE)
    @PreAuthorize("hasRole('USER')")
    public ResponseEntity<Object> update(@PathVariable Long id, @Valid @RequestBody UserUpdateBindingModel userUpdateBindingModel,
                                         BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(com.example.restapi.util.JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }

        UserServiceModel userServiceModel = userService.getById(id);
        if (userServiceModel == null) {
            return ResponseEntity
                    .status(HttpStatus.NOT_FOUND)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_DOES_NOT_EXIST));
        }
        if (!Objects.equals(userServiceModel.getId(), id)) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(UserMessages.USER_MISMATCH));
        }
        modelMapper.map(userUpdateBindingModel, userServiceModel);
        UserServiceModel updatedUser = userService.update(userServiceModel);
        return ResponseEntity.ok(modelMapper.map(updatedUser, UserDetailsViewModel.class));
    }

    @PostMapping(value = "/register",
            consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Object> register(@Valid @RequestBody UserRegisterBindingModel userRegisterBindingModel,
                                           BindingResult bindingResult) {

        if (bindingResult.hasErrors() || !userRegisterBindingModel.getPassword().equals(userRegisterBindingModel.getConfirmPassword())) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST)
                    .body(JSONResponse.jsonFromStream(bindingResult
                            .getFieldErrors()
                            .stream()
                            .map(DefaultMessageSourceResolvable::getDefaultMessage)));
        }
        UserServiceModel userServiceModel = modelMapper.map(userRegisterBindingModel, UserServiceModel.class);
        if (userService.existsByUsername(userServiceModel.getUsername())) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(UserMessages.USERNAME_ALREADY_EXISTS));
        }
        ShoppingCartServiceModel shoppingCart = shoppingCartService.create();
        userServiceModel.setCart(shoppingCart);
        UserServiceModel user = this.userService.register(userServiceModel);

        if (user == null) {
            return ResponseEntity
                    .status(HttpStatus.CONFLICT)
                    .body(JSONResponse.jsonFromString(UserMessages.REGISTRATION_NOT_SUCCESSFUL));
        }

        return ResponseEntity.ok(modelMapper.map(user, UserDetailsViewModel.class));
    }

    private void mapUserFields(UserServiceModel dbUser, UserListViewModel mappedUser) {
        if (dbUser.getAuthorities() == null) {
            return;
        }
        mappedUser.setRoot(dbUser.getAuthorities().stream().anyMatch(role -> role.getAuthority().equals(RolesData.ROLE_ROOT)));
        mappedUser.setAdministrator(dbUser.getAuthorities().stream().anyMatch(role -> role.getAuthority().equals(RolesData.ROLE_ADMIN)));
        mappedUser
                .setActive(dbUser.isEnabled() && dbUser.isAccountNonLocked());
    }
}
