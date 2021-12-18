package com.example.pathfinder.model.entity;

import com.example.pathfinder.model.enums.RoleNameEnum;

import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "roles")
public class Role extends BaseEntity {
    private RoleNameEnum role;

    public Role() {
    }

    @Enumerated(EnumType.STRING)
    @NotNull
    public RoleNameEnum getRole() {
        return role;
    }

    public void setRole(RoleNameEnum role) {
        this.role = role;
    }
}
