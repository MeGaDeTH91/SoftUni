package com.example.restapi.model.view;

import java.time.LocalDateTime;
import java.util.Set;

public class OrderViewModel {
    private Long id;
    private LocalDateTime created;
    private Set<ProductListViewModel> products;

    public OrderViewModel() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Set<ProductListViewModel> getProducts() {
        return products;
    }

    public void setProducts(Set<ProductListViewModel> products) {
        this.products = products;
    }

    public LocalDateTime getCreated() {
        return created;
    }

    public void setCreated(LocalDateTime created) {
        this.created = created;
    }
}
