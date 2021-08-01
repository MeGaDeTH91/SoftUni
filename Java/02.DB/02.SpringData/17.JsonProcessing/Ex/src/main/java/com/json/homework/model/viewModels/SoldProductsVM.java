package com.json.homework.model.viewModels;

import com.google.gson.annotations.Expose;

import java.util.List;

public class SoldProductsVM {
    @Expose
    private int count;
    @Expose
    private List<ProductNameAndPriceVM> products;

    public SoldProductsVM() {
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public List<ProductNameAndPriceVM> getProducts() {
        return products;
    }

    public void setProducts(List<ProductNameAndPriceVM> products) {
        this.products = products;
    }
}
