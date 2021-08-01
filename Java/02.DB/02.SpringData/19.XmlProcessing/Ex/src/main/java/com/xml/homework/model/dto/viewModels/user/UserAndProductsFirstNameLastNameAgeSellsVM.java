package com.xml.homework.model.dto.viewModels.user;

import com.xml.homework.model.dto.viewModels.product.UsersAndProductsSoldProductsVM;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "user")
@XmlAccessorType(XmlAccessType.FIELD)
public class UserAndProductsFirstNameLastNameAgeSellsVM {
    @XmlAttribute(name = "first-name")
    private String firstName;
    @XmlAttribute(name = "last-name")
    private String lastName;
    @XmlAttribute
    private int age;
    @XmlElement(name = "sold-products")
    private UsersAndProductsSoldProductsVM soldProducts;

    public UserAndProductsFirstNameLastNameAgeSellsVM() {
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

    public UsersAndProductsSoldProductsVM getSoldProducts() {
        return soldProducts;
    }

    public void setSoldProducts(UsersAndProductsSoldProductsVM soldProducts) {
        this.soldProducts = soldProducts;
    }
}
