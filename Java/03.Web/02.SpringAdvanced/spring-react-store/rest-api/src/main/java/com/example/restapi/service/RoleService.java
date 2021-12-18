package com.example.restapi.service;

import com.example.restapi.model.service.RoleServiceModel;

import java.util.Set;

public interface RoleService {
    void seedRoles();

    Set<RoleServiceModel> findAll();

    RoleServiceModel findByAuthority(String authority);
}
