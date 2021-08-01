package com.xml.homework.model.dto.viewModels.user;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "users")
@XmlAccessorType(XmlAccessType.FIELD)
public class UserSoldProductsRootVM {
    @XmlElement(name = "user")
    private List<UserSoldProductsVM> users;

    public List<UserSoldProductsVM> getUsers() {
        return users;
    }

    public void setUsers(List<UserSoldProductsVM> users) {
        this.users = users;
    }
}
