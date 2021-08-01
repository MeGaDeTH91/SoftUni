package com.xml.homework.model.dto.viewModels.product;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "sold-products")
@XmlAccessorType(XmlAccessType.FIELD)
public class UsersAndProductsSoldProductsVM {
    @XmlAttribute
    private int count;
    @XmlElement(name = "product")
    private List<UsersAndProductsProductNameAndPriceVM> products;

    public UsersAndProductsSoldProductsVM() {
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public List<UsersAndProductsProductNameAndPriceVM> getProducts() {
        return products;
    }

    public void setProducts(List<UsersAndProductsProductNameAndPriceVM> products) {
        this.products = products;
    }
}
