package com.example.restapi.service.impl;

import com.example.restapi.constants.RolesData;
import com.example.restapi.model.entity.Role;
import com.example.restapi.model.entity.User;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.model.service.ReviewServiceModel;
import com.example.restapi.model.service.RoleServiceModel;
import com.example.restapi.model.service.UserServiceModel;
import com.example.restapi.repository.UserRepository;
import com.example.restapi.service.RoleService;
import com.example.restapi.service.UserService;
import org.modelmapper.ModelMapper;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.LinkedHashSet;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {
    private final RoleService roleService;
    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final ModelMapper modelMapper;

    public UserServiceImpl(RoleService roleService, UserRepository userRepository, PasswordEncoder passwordEncoder, ModelMapper modelMapper) {
        this.roleService = roleService;
        this.userRepository = userRepository;
        this.passwordEncoder = passwordEncoder;
        this.modelMapper = modelMapper;
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        Optional<User> userEntityOpt = userRepository.findByUsername(username);
        return userEntityOpt.
                map(this::map).
                orElseThrow(() -> new UsernameNotFoundException("User " + username + " not found!"));
    }

    @Override
    public UserServiceModel register(UserServiceModel userServiceModel) {
        if (this.userRepository.count() == 0) {
            userServiceModel.setAuthorities(this.roleService.findAll());
        } else {
            userServiceModel.setAuthorities(new LinkedHashSet<>());
            userServiceModel.getAuthorities().add(this.roleService.findByAuthority(RolesData.ROLE_USER));
        }

        User user = this.modelMapper.map(userServiceModel, User.class);
        user.setPassword(this.passwordEncoder.encode(userServiceModel.getPassword()));
        user.setAccountNonLocked(true);
        user.setEnabled(true);

        return this.modelMapper.map(this.userRepository.saveAndFlush(user), UserServiceModel.class);
    }

    @Override
    public boolean existsByUsername(String username) {
        return userRepository.existsByUsername(username);
    }

    @Override
    public boolean existsById(Long id) {
        return userRepository.existsById(id);
    }

    @Override
    public UserServiceModel getById(Long id) {
        var repoUser = userRepository.findById(id).orElse(null);
        if (repoUser == null) {
            return null;
        }
        var mappedUser = modelMapper.map(repoUser, UserServiceModel.class);
        syncNestedCollections(repoUser, mappedUser);

        return mappedUser;
    }

    @Override
    public UserServiceModel getByUsername(String username) {
        var repoUser = userRepository.findByUsername(username).orElse(null);
        if (repoUser == null) {
            return null;
        }
        var mappedUser = modelMapper.map(repoUser, UserServiceModel.class);
        syncNestedCollections(repoUser, mappedUser);

        return mappedUser;
    }

    @Override
    public UserServiceModel update(UserServiceModel userServiceModel) {
        User user = userRepository.findById(userServiceModel.getId()).orElse(null);
        if (user == null) {
            return null;
        }
        mapUserUpdateData(userServiceModel, user);

        return modelMapper.map(this.userRepository.saveAndFlush(user), UserServiceModel.class);
    }

    @Override
    public List<UserServiceModel> getAllUsers() {
        return userRepository
                .findAll()
                .stream()
                .map(dbUser -> {
                    UserServiceModel mappedUser = modelMapper.map(dbUser, UserServiceModel.class);
                    mapAuthorities(dbUser, mappedUser);

                    return mappedUser;
                })
                .collect(Collectors.toList());
    }

    @Override
    public UserServiceModel changeAdminStatus(Long id) {
        User user = userRepository.findById(id).orElse(null);
        if (user == null || user.getAuthorities() == null) {
            return null;
        }

        if (userIsAdmin(user)) {
            user.getAuthorities().removeIf(role -> role.getAuthority().equals(RolesData.ROLE_ADMIN));
        } else {
            RoleServiceModel adminRole = roleService.findByAuthority(RolesData.ROLE_ADMIN);
            user.getAuthorities().add(modelMapper.map(adminRole, Role.class));
        }
        userRepository.save(user);

        return modelMapper.map(user, UserServiceModel.class);
    }

    @Override
    public UserServiceModel changeActivityStatus(Long id) {
        User user = userRepository.findById(id).orElse(null);
        if (user == null) {
            return null;
        }

        if (userIsActive(user)) {
            user.setAccountNonLocked(false);
            user.setEnabled(false);
        } else {
            user.setAccountNonLocked(true);
            user.setEnabled(true);
        }
        userRepository.save(user);

        return modelMapper.map(user, UserServiceModel.class);
    }

    private boolean userIsActive(User user) {
        return user.isEnabled() && user.isAccountNonLocked();
    }

    private boolean userIsAdmin(User user) {
        return user.getAuthorities().stream().anyMatch(role -> role.getAuthority().equals(RolesData.ROLE_ADMIN));
    }

    private void mapUserUpdateData(UserServiceModel userServiceModel, User user) {
        if (userServiceModel.getEmail() != null && !userServiceModel.getEmail().equals(user.getEmail())) {
            user.setEmail(userServiceModel.getEmail());
        }
        if (userServiceModel.getFirstName() != null && !userServiceModel.getFirstName().equals(user.getFirstName())) {
            user.setFirstName(userServiceModel.getFirstName());
        }
        if (userServiceModel.getLastName() != null && !userServiceModel.getLastName().equals(user.getLastName())) {
            user.setLastName(userServiceModel.getLastName());
        }
        if (userServiceModel.getAddress() != null && !userServiceModel.getAddress().equals(user.getAddress())) {
            user.setAddress(userServiceModel.getAddress());
        }
    }

    private UserDetails map(User user) {
        return new org.springframework.security.core.userdetails.User(
                user.getUsername(),
                user.getPassword(),
                user.getAuthorities());
    }

    private void syncNestedCollections(User repoUser, UserServiceModel mappedUser) {
        mapAuthorities(repoUser, mappedUser);
        if (mappedUser.getReviews() == null && repoUser.getReviews() != null) {
            mappedUser.setReviews(repoUser
                    .getReviews()
                    .stream()
                    .map(review -> modelMapper.map(review, ReviewServiceModel.class))
                    .collect(Collectors.toSet()));
        }
        if (mappedUser.getCart().getProducts() == null && repoUser.getCart().getProducts() != null) {
            mappedUser.getCart().setProducts(repoUser
                    .getCart()
                    .getProducts()
                    .stream()
                    .map(review -> modelMapper.map(review, ProductServiceModel.class))
                    .collect(Collectors.toSet()));
        }
    }

    private void mapAuthorities(User repoUser, UserServiceModel mappedUser) {
        if (mappedUser.getAuthorities() == null && repoUser.getAuthorities() != null) {
            mappedUser.setAuthorities(repoUser
                    .getAuthorities()
                    .stream()
                    .map(role -> modelMapper.map(role, RoleServiceModel.class))
                    .collect(Collectors.toSet()));
        }
    }
}
