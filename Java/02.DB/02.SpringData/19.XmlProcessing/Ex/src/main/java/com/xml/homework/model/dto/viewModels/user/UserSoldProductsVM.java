package com.xml.homework.model.dto.viewModels.user;

import com.xml.homework.model.dto.viewModels.product.UserSoldProductWithBuyerVM;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementWrapper;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "user")
@XmlAccessorType(XmlAccessType.FIELD)
public class UserSoldProductsVM {
    @XmlAttribute(name = "first-name")
    private String firstName;
    @XmlAttribute(name = "last-name")
    private String lastName;
    @XmlElementWrapper(name = "sold-products")
    @XmlElement(name = "product")
    private List<UserSoldProductWithBuyerVM> soldProducts;

    public UserSoldProductsVM() {
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

    public List<UserSoldProductWithBuyerVM> getSoldProducts() {
        return soldProducts;
    }

    public void setSoldProducts(List<UserSoldProductWithBuyerVM> soldProducts) {
        this.soldProducts = soldProducts;
    }
}
