package com.java.exam.model.view;

import java.util.List;

public class UserViewModel {
    private String username;
    private List<ShipViewModel> ships;

    public UserViewModel() {
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public List<ShipViewModel> getShips() {
        return ships;
    }

    public void setShips(List<ShipViewModel> ships) {
        this.ships = ships;
    }
}
