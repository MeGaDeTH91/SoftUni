package com.demo.examprep.repository;

import com.demo.examprep.model.entity.Category;
import com.demo.examprep.model.enumerations.CategoryNameEnum;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface CategoryRepository extends JpaRepository<Category, Long> {
    Optional<Category> findByName(CategoryNameEnum name);
}
