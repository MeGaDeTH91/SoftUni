package com.demo.examprep.repository;

import com.demo.examprep.model.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {
    Optional<User> findByUsernameAndPassword(String username, String password);
    @Query("SELECT u FROM User AS u ORDER BY SIZE(u.orders) DESC")
    List<User> findAllByUsersOrderByOrderCountDesc();
    boolean existsByEmail(String email);
    boolean existsByUsername(String username);
}
