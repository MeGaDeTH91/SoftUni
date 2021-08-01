package com.xml.homework.model.dto.viewModels.user;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.List;

@XmlRootElement(name = "users")
@XmlAccessorType(XmlAccessType.FIELD)
public class UsersAndProductsRootVM {
    @XmlAttribute(name = "count")
    private int usersCount;
    @XmlElement(name = "user")
    private List<UserAndProductsFirstNameLastNameAgeSellsVM> users;

    public UsersAndProductsRootVM() {
    }

    public int getUsersCount() {
        return usersCount;
    }

    public void setUsersCount(int usersCount) {
        this.usersCount = usersCount;
    }

    public List<UserAndProductsFirstNameLastNameAgeSellsVM> getUsers() {
        return users;
    }

    public void setUsers(List<UserAndProductsFirstNameLastNameAgeSellsVM> users) {
        this.users = users;
    }
}
