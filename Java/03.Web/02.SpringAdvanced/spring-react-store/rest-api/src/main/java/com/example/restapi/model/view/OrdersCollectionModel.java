package com.example.restapi.model.view;

import java.util.Set;

public class OrdersCollectionModel {
    private Set<OrderViewModel> orders;

    public OrdersCollectionModel() {
    }

    public Set<OrderViewModel> getOrders() {
        return orders;
    }

    public void setOrders(Set<OrderViewModel> orders) {
        this.orders = orders;
    }
}
