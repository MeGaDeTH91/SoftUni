package com.json.homework.model.viewModels;

import com.google.gson.annotations.Expose;

import java.util.List;

public class UsersWithSoldProductsCountVM {
    @Expose
    private int usersCount;
    @Expose
    private List<UserFirstNameLastNameAgeSellsVM> users;

    public UsersWithSoldProductsCountVM() {
    }

    public int getUsersCount() {
        return usersCount;
    }

    public void setUsersCount(int usersCount) {
        this.usersCount = usersCount;
    }

    public List<UserFirstNameLastNameAgeSellsVM> getUsers() {
        return users;
    }

    public void setUsers(List<UserFirstNameLastNameAgeSellsVM> users) {
        this.users = users;
    }
}
