package com.json.homework.model.viewModels;

import com.google.gson.annotations.Expose;

import java.util.List;

public class UserWithSoldProductsVM {
    @Expose
    private String firstName;
    @Expose
    private String lastName;
    @Expose
    private List<ProductsSoldWithBuyerVM> soldProducts;

    public UserWithSoldProductsVM() {
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public List<ProductsSoldWithBuyerVM> getSoldProducts() {
        return soldProducts;
    }

    public void setSoldProducts(List<ProductsSoldWithBuyerVM> soldProducts) {
        this.soldProducts = soldProducts;
    }
}
