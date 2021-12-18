package com.java.exam.service;

import com.java.exam.model.service.ShipServiceModel;
import com.java.exam.model.view.ShipViewModel;

import java.util.List;

public interface ShipService {
    void addShip(ShipServiceModel shipServiceModel);

    List<ShipViewModel> getShipsOrderedByPowerThenHealth();

    ShipViewModel getShipViewModelById(Long attacker);

    void removeShipById(Long id);

    void setNewShipHealth(Long id, Long health);
}
