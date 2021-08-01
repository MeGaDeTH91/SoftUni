package com.example.springintro.repository;

import com.example.springintro.model.entity.Author;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface AuthorRepository extends JpaRepository<Author, Long> {

    List<Author> findAllByFirstNameEndingWith(String endsWith);

    @Query("SELECT a FROM Book b join b.author a GROUP BY a.id ORDER BY SUM(b.copies) DESC")
    List<Author> findAllAuthorsByBookTotalCopiesDesc();
}
