package com.demo.examprep.service.impl;

import com.demo.examprep.model.entity.Order;
import com.demo.examprep.model.service.OrderServiceModel;
import com.demo.examprep.model.view.OrderViewModel;
import com.demo.examprep.repository.OrderRepository;
import com.demo.examprep.service.CategoryService;
import com.demo.examprep.service.OrderService;
import com.demo.examprep.service.UserService;
import com.demo.examprep.util.CurrentUser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class OrderServiceImpl implements OrderService {
    private final OrderRepository orderRepository;
    private final ModelMapper modelMapper;
    private final CurrentUser currentUser;
    private final UserService userService;
    private final CategoryService categoryService;

    public OrderServiceImpl(OrderRepository orderRepository, ModelMapper modelMapper,
                            CurrentUser currentUser, UserService userService, CategoryService categoryService) {
        this.orderRepository = orderRepository;
        this.modelMapper = modelMapper;
        this.currentUser = currentUser;
        this.userService = userService;
        this.categoryService = categoryService;
    }

    @Override
    public void addOrder(OrderServiceModel orderServiceModel) {
        if (!currentUser.LoggedIn()) {
            return;
        }
        Order order = modelMapper.map(orderServiceModel, Order.class);
        order.setEmployee(userService.getUserById(currentUser.getId()));
        order.setCategory(categoryService.getCategoryByName(orderServiceModel.getCategory()));

        orderRepository.save(order);
    }

    @Override
    public List<OrderViewModel> getOrdersByPriceDesc() {
        return orderRepository
                .findAllByOrderByPriceDesc()
                .stream()
                .map(order -> modelMapper.map(order, OrderViewModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public void readyOrder(Long id) {
        orderRepository.deleteById(id);
    }
}
