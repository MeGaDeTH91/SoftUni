package com.xml.homework.model.dto.viewModels.category;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "categories")
@XmlAccessorType(XmlAccessType.FIELD)
public class CategoriesByProductRootVM {
    @XmlElement(name = "category")
    private List<CategoriesByProductVM> categories;

    public List<CategoriesByProductVM> getCategories() {
        return categories;
    }

    public void setCategories(List<CategoriesByProductVM> categories) {
        this.categories = categories;
    }
}
