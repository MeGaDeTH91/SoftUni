package com.example.springintro.repository;

import com.example.springintro.model.entity.AgeRestriction;
import com.example.springintro.model.entity.Book;
import com.example.springintro.model.entity.EditionType;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;

@Repository
public interface BookRepository extends JpaRepository<Book, Long> {

    List<Book> findAllByReleaseDateBefore(LocalDate releaseDateBefore);

    List<Book> findAllByAuthor_FirstNameAndAuthor_LastNameOrderByReleaseDateDescTitle(String author_firstName, String author_lastName);

    List<Book> findAllByAgeRestriction(AgeRestriction ageRestriction);

    List<Book> findAllByEditionTypeAndCopiesLessThan(EditionType editionType, int copies);

    List<Book> findAllByPriceLessThanOrPriceGreaterThan(BigDecimal lowerThan, BigDecimal higherThan);

    @Query("SELECT b FROM Book b WHERE FUNCTION('year', b.releaseDate) <> :year")
    List<Book> findAllByReleaseDateYearNotEqualTo(@Param("year") int year);

    List<Book> findAllByTitleContaining(String titlePart);

    @Query("SELECT b FROM Book b WHERE b.author.lastName LIKE :startsWith%")
    List<Book> findAllByAuthorLastNameStartsWith(@Param("startsWith") String startsWith);

    @Query("SELECT COUNT(b.id) FROM Book b WHERE LENGTH(b.title) > :targetLength")
    int selectBooksCountWithTitleLengthGreaterThan(@Param("targetLength") int targetLength);

    @Query(value = "SELECT b.title, b.edition_type, b.age_restriction, b.price FROM books b WHERE b.title = :title",
            nativeQuery = true)
    Object findBookByGivenTitle(@Param("title") String title);

    @Modifying
    @Query("UPDATE Book b SET b.copies = b.copies + :copies WHERE b.releaseDate > :releaseDate")
    @Transactional
    int updateCopiesOfBooksByReleaseDate(LocalDate releaseDate, int copies);
}
