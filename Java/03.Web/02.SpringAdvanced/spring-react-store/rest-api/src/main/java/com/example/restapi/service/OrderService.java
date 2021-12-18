package com.example.restapi.service;

import com.example.restapi.model.service.OrderServiceModel;

import java.util.List;

public interface OrderService {
    OrderServiceModel create(OrderServiceModel orderServiceModel);

    List<OrderServiceModel> getUserOrders(Long id);
}
