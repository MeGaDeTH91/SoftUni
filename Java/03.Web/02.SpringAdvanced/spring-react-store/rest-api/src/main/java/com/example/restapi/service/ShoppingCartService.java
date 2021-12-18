package com.example.restapi.service;

import com.example.restapi.model.entity.ShoppingCart;
import com.example.restapi.model.service.ShoppingCartServiceModel;

public interface ShoppingCartService {
    ShoppingCartServiceModel create();

    boolean addProduct(Long cartId, Long productId);

    boolean removeProduct(Long cartId, Long productId);

    boolean emptyCart(Long cartId);

    ShoppingCart get(Long id);
}
