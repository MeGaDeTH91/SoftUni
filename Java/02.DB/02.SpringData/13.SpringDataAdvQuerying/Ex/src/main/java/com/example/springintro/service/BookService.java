package com.example.springintro.service;

import com.example.springintro.model.entity.AgeRestriction;
import com.example.springintro.model.entity.EditionType;

import java.io.IOException;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;

public interface BookService {
    void seedBooks() throws IOException;

    List<String> findAllBooksBeforeDate(LocalDate localDate);

    List<String> findAllBooksByAgeRestriction(AgeRestriction ageRestriction);

    List<String> findAllBooksByEditionTypeAndCopiesLessThan(EditionType editionType, int copies);

    List<String> findAllBooksByPriceBoundaries(BigDecimal lowerThan, BigDecimal higherThan);

    List<String> findAllBooksWithReleaseYearNotEqualTo(int year);

    List<String> findAllBooksWithTitleContains(String titlePart);

    List<String> findAllByAuthorLastNameStartsWith(String startsWith);

    int getBooksCountWithTitleLengthGreaterThan(int targetLength);

    String getSpecificBookDetailsByBookTitle(String title);

    int updateCopiesOfBooksByReleaseDate(LocalDate releaseDate, int copies);
}
