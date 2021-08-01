package com.example.springintro.service.impl;

import com.example.springintro.model.entity.*;
import com.example.springintro.repository.BookRepository;
import com.example.springintro.service.AuthorService;
import com.example.springintro.service.BookService;
import com.example.springintro.service.CategoryService;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class BookServiceImpl implements BookService {

    private static final String BOOKS_FILE_PATH = "src/main/resources/files/books.txt";

    private final BookRepository bookRepository;
    private final AuthorService authorService;
    private final CategoryService categoryService;

    public BookServiceImpl(BookRepository bookRepository, AuthorService authorService, CategoryService categoryService) {
        this.bookRepository = bookRepository;
        this.authorService = authorService;
        this.categoryService = categoryService;
    }

    @Override
    public void seedBooks() throws IOException {
        if (bookRepository.count() > 0) {
            return;
        }

        Files
                .readAllLines(Path.of(BOOKS_FILE_PATH))
                .forEach(row -> {
                    String[] bookInfo = row.split("\\s+");

                    Book book = createBookFromInfo(bookInfo);

                    bookRepository.save(book);
                });
    }

    @Override
    public List<String> findAllBooksBeforeDate(LocalDate localDate) {
        return bookRepository
                .findAllByReleaseDateBefore(localDate)
                .stream()
                .map(book -> String.format("%s %s %.2f",
                        book.getTitle(),
                        book.getEditionType().name(),
                        book.getPrice()))
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllBooksByAgeRestriction(AgeRestriction ageRestriction) {
        return bookRepository
                .findAllByAgeRestriction(ageRestriction)
                .stream().map(Book::getTitle)
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllBooksByEditionTypeAndCopiesLessThan(EditionType editionType, int copies) {
        return bookRepository
                .findAllByEditionTypeAndCopiesLessThan(editionType, copies)
                .stream().map(Book::getTitle)
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllBooksByPriceBoundaries(BigDecimal lowerThan, BigDecimal higherThan) {
        return bookRepository
                .findAllByPriceLessThanOrPriceGreaterThan(lowerThan, higherThan)
                .stream().map(book -> String.format("%s - $%.2f", book.getTitle(), book.getPrice()))
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllBooksWithReleaseYearNotEqualTo(int year) {
        return bookRepository
                .findAllByReleaseDateYearNotEqualTo(year)
                .stream().map(Book::getTitle)
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllBooksWithTitleContains(String titlePart) {
        return bookRepository
                .findAllByTitleContaining(titlePart)
                .stream().map(Book::getTitle)
                .collect(Collectors.toList());
    }

    @Override
    public List<String> findAllByAuthorLastNameStartsWith(String startsWith) {
        return bookRepository
                .findAllByAuthorLastNameStartsWith(startsWith)
                .stream().map(book ->
                        String.format("%s (%s %s)",
                                book.getTitle(),
                                book.getAuthor().getFirstName(),
                                book.getAuthor().getLastName()))
                .collect(Collectors.toList());
    }

    @Override
    public int getBooksCountWithTitleLengthGreaterThan(int targetLength) {
        return bookRepository.selectBooksCountWithTitleLengthGreaterThan(targetLength);
    }

    @Override
    public String getSpecificBookDetailsByBookTitle(String title) {
        var resultObjArr = (Object[])bookRepository.findBookByGivenTitle(title);
        String bookTitle = resultObjArr[0].toString();
        EditionType editionType = EditionType.values()[Integer.parseInt(resultObjArr[1].toString())];
        AgeRestriction ageRestriction = AgeRestriction.values()[Integer.parseInt(resultObjArr[2].toString())];
        double price = Double.parseDouble(resultObjArr[3].toString());
        return String.format("%s %s %s %.2f",
                bookTitle,
                editionType.name(),
                ageRestriction.name(),
                price);
    }

    @Override
    public int updateCopiesOfBooksByReleaseDate(LocalDate releaseDate, int copies) {
        return bookRepository.updateCopiesOfBooksByReleaseDate(releaseDate, copies);
    }

    private Book createBookFromInfo(String[] bookInfo) {
        EditionType editionType = EditionType.values()[Integer.parseInt(bookInfo[0])];
        LocalDate releaseDate = LocalDate
                .parse(bookInfo[1], DateTimeFormatter.ofPattern("d/M/yyyy"));
        Integer copies = Integer.parseInt(bookInfo[2]);
        BigDecimal price = new BigDecimal(bookInfo[3]);
        AgeRestriction ageRestriction = AgeRestriction
                .values()[Integer.parseInt(bookInfo[4])];
        String title = Arrays.stream(bookInfo)
                .skip(5)
                .collect(Collectors.joining(" "));

        Author author = authorService.getRandomAuthor();
        Set<Category> categories = categoryService
                .getRandomCategories();

        return new Book(editionType, releaseDate, copies, price, ageRestriction, title, author, categories);

    }
}
