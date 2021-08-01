package com.xml.homework.repository;

import com.xml.homework.model.entity.Category;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CategoryRepository extends JpaRepository<Category, Long> {

    @Query("SELECT c FROM Category AS c ORDER BY c.products.size DESC")
    List<Category> findAllCategoriesOrderByProductsDesc();
}
