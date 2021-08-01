package com.xml.homework.model.dto.viewModels.product;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "products")
@XmlAccessorType(XmlAccessType.FIELD)
public class ProductsInRangeRootVM {
    @XmlElement(name = "product")
    private List<ProductsInRangeVM> products;

    public List<ProductsInRangeVM> getProducts() {
        return products;
    }

    public void setProducts(List<ProductsInRangeVM> products) {
        this.products = products;
    }
}
