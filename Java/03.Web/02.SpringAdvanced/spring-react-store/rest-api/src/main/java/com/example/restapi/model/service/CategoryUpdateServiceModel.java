package com.example.restapi.model.service;

public class CategoryUpdateServiceModel extends BaseServiceModel {
    private String title;
    private String imageURL;

    public CategoryUpdateServiceModel() {
    }

    public CategoryUpdateServiceModel(Long id) {
        this.setId(id);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }
}
