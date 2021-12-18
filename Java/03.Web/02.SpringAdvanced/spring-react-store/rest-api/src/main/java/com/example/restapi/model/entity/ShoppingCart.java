package com.example.restapi.model.entity;

import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.Table;
import java.util.Set;

@Entity
@Table(name = "carts")
public class ShoppingCart extends BaseEntity {
    private Set<Product> products;

    public ShoppingCart() {
    }

    @ManyToMany(targetEntity = Product.class, fetch = FetchType.EAGER)
    @JoinTable(name = "carts_products",
            joinColumns = @JoinColumn(name = "shopping_cart_id", referencedColumnName = "id"),
            inverseJoinColumns = @JoinColumn(name = "products_id", referencedColumnName = "id")
    )
    public Set<Product> getProducts() {
        return products;
    }

    public void setProducts(Set<Product> products) {
        this.products = products;
    }
}
