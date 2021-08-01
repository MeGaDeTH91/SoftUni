package com.json.homework.model.viewModels;

import com.google.gson.annotations.Expose;

public class UserFirstNameLastNameAgeSellsVM {
    @Expose
    private String firstName;
    @Expose
    private String lastName;
    @Expose
    private int age;
    @Expose
    private SoldProductsVM soldProducts;

    public UserFirstNameLastNameAgeSellsVM() {
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

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public SoldProductsVM getSoldProducts() {
        return soldProducts;
    }

    public void setSoldProducts(SoldProductsVM soldProducts) {
        this.soldProducts = soldProducts;
    }
}
