package com.demo.examprep.service;

import com.demo.examprep.model.service.OrderServiceModel;
import com.demo.examprep.model.view.OrderViewModel;

import java.util.List;

public interface OrderService {
    void addOrder(OrderServiceModel orderServiceModel);

    List<OrderViewModel> getOrdersByPriceDesc();

    void readyOrder(Long id);
}
