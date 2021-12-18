package com.example.restapi.service.impl;

import com.example.restapi.model.entity.Order;
import com.example.restapi.model.service.OrderServiceModel;
import com.example.restapi.model.service.ProductServiceModel;
import com.example.restapi.repository.OrderRepository;
import com.example.restapi.service.OrderService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class OrderServiceImpl implements OrderService {
    private final OrderRepository orderRepository;
    private final ModelMapper modelMapper;

    public OrderServiceImpl(OrderRepository orderRepository, ModelMapper modelMapper) {
        this.orderRepository = orderRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public OrderServiceModel create(OrderServiceModel orderServiceModel) {
        Order order = modelMapper.map(orderServiceModel, Order.class);

        return modelMapper.map(orderRepository.saveAndFlush(order), OrderServiceModel.class);
    }

    @Override
    public List<OrderServiceModel> getUserOrders(Long id) {
        var dbOrders = orderRepository
                .findAllByCustomer_Id(id);
        var mappedOrders = dbOrders
                .stream()
                .map(order -> modelMapper.map(order, OrderServiceModel.class))
                .collect(Collectors.toList());

        mapOrderProducts(dbOrders, mappedOrders);

        return mappedOrders;
    }

    private void mapOrderProducts(Set<Order> dbOrders, List<OrderServiceModel> mappedOrders) {
        if (mappedOrders.stream().allMatch(order -> order.getProducts() == null)) {
            for (Order order : dbOrders) {
                mappedOrders
                        .stream()
                        .filter(mappedOrder -> mappedOrder.getId().equals(order.getId()))
                        .findFirst()
                        .ifPresent(tempMappedOrder -> tempMappedOrder.setProducts(order.getProducts()
                                .stream()
                                .map(product -> modelMapper.map(product, ProductServiceModel.class))
                                .collect(Collectors.toSet())));
            }
        }
    }
}
