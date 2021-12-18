package com.java.exam.service.impl;

import com.java.exam.model.entity.Ship;
import com.java.exam.model.service.ShipServiceModel;
import com.java.exam.model.view.ShipViewModel;
import com.java.exam.repository.ShipRepository;
import com.java.exam.service.CategoryService;
import com.java.exam.service.ShipService;
import com.java.exam.service.UserService;
import com.java.exam.util.CurrentUser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class ShipServiceImpl implements ShipService {
    private final ShipRepository shipRepository;
    private final ModelMapper modelMapper;
    private final CurrentUser currentUser;
    private final UserService userService;
    private final CategoryService categoryService;

    public ShipServiceImpl(ShipRepository shipRepository, ModelMapper modelMapper, CurrentUser currentUser, UserService userService, CategoryService categoryService) {
        this.shipRepository = shipRepository;
        this.modelMapper = modelMapper;
        this.currentUser = currentUser;
        this.userService = userService;
        this.categoryService = categoryService;
    }

    @Override
    public void addShip(ShipServiceModel shipServiceModel) {
        if (!currentUser.LoggedIn()) {
            return;
        }
        Ship ship = modelMapper.map(shipServiceModel, Ship.class);
        ship.setUser(userService.getUserById(currentUser.getId()));
        ship.setCategory(categoryService.getCategoryByName(shipServiceModel.getCategory()));

        shipRepository.save(ship);
    }

    @Override
    public List<ShipViewModel> getShipsOrderedByPowerThenHealth() {
        return shipRepository
                .findAllByOrderByPowerAscHealthAsc()
                .stream()
                .map(ship -> modelMapper.map(ship, ShipViewModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public ShipViewModel getShipViewModelById(Long id) {
        return shipRepository.findById(id)
                .map(ship -> modelMapper.map(ship, ShipViewModel.class)).orElse(null);
    }

    @Override
    public void removeShipById(Long id) {
        shipRepository.deleteById(id);
    }

    @Override
    public void setNewShipHealth(Long id, Long newHealth) {
        Ship ship = getShipById(id);
        if (ship == null) {
            return;
        }
        ship.setHealth(newHealth);
        shipRepository.save(ship);
    }

    private Ship getShipById(Long id){
        return shipRepository.findById(id).orElse(null);
    }
}
