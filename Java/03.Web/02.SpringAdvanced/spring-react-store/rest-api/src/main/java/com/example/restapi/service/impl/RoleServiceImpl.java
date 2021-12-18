package com.example.restapi.service.impl;

import com.example.restapi.constants.RolesData;
import com.example.restapi.model.entity.Role;
import com.example.restapi.model.service.RoleServiceModel;
import com.example.restapi.repository.RoleRepository;
import com.example.restapi.service.RoleService;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Set;
import java.util.stream.Collectors;

@Service
public class RoleServiceImpl implements RoleService {
    private final RoleRepository roleRepository;
    private final ModelMapper modelMapper;

    @Autowired
    public RoleServiceImpl(RoleRepository roleRepository, ModelMapper modelMapper) {
        this.roleRepository = roleRepository;
        this.modelMapper = modelMapper;

    }

    @Override
    public void seedRoles() {
        if (this.roleRepository.count() == 0) {
            this.roleRepository.saveAndFlush(new Role(RolesData.ROLE_USER));
            this.roleRepository.saveAndFlush(new Role(RolesData.ROLE_ADMIN));
            this.roleRepository.saveAndFlush(new Role(RolesData.ROLE_ROOT));
        }
    }

    @Override
    public Set<RoleServiceModel> findAll() {
        return this.roleRepository.findAll()
                .stream()
                .map(r -> this.modelMapper.map(r, RoleServiceModel.class))
                .collect(Collectors.toSet());
    }

    @Override
    public RoleServiceModel findByAuthority(String authority) {
        return this.modelMapper.map(this.roleRepository.findByAuthority(authority), RoleServiceModel.class);
    }
}
