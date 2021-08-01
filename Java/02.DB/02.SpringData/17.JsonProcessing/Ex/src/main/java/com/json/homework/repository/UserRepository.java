package com.json.homework.repository;

import com.json.homework.model.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {

    @Query("SELECT u FROM User AS u JOIN Product AS p ON p.seller.id = u.id " +
            "WHERE p.buyer IS NOT NULL " +
            "GROUP BY u.id " +
            "ORDER BY u.lastName, u.firstName")
    List<User> findAllWithAtLeastOneSoldProductOrderByNameAsc();

    @Query("SELECT u FROM User u " +
            "WHERE u.soldProducts.size > 0 " +
            "ORDER BY u.soldProducts.size DESC, " +
            "u.lastName ASC")
    List<User> findAllUsersWithAtLeastOneSoldProductOrderByProductsNumDesc();
}
