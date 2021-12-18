package com.example.restapi.model.view;

public class ProductListViewModel {
    private Long id;
    private String title;

    public ProductListViewModel() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
}
