package com.spring.intro.homework.services.impl;

import com.spring.intro.homework.models.entity.Author;
import com.spring.intro.homework.models.entity.Book;
import com.spring.intro.homework.models.entity.Category;
import com.spring.intro.homework.models.enumerations.AgeRestriction;
import com.spring.intro.homework.models.enumerations.EditionType;
import com.spring.intro.homework.repositories.BookRepository;
import com.spring.intro.homework.services.interfaces.AuthorService;
import com.spring.intro.homework.services.interfaces.BookService;
import com.spring.intro.homework.services.interfaces.CategoryService;
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
        if(bookRepository.count() < 1) {
            Files.readAllLines(Path.of(BOOKS_FILE_PATH))
                    .stream()
                    .filter(book -> !book.isEmpty())
                    .forEach(row -> {
                        String[] rowTokens = row.split("\\s+");

                        Book book = createBookFromTokens(rowTokens);

                        bookRepository.save(book);
                    });
        }
    }

    @Override
    public List<String> findAllBooksBeforeYear(int year) {
        return bookRepository.findAllByReleaseDateBefore(LocalDate.of(year, 1, 1)).stream().map(book -> {
            Author author = book.getAuthor();
            if(author.getFirstName() != null) {
                return String.format("%s %s", author.getFirstName(), author.getLastName());
            } else {
                return author.getLastName();
            }
        })
                .distinct()
                .collect(Collectors.toList());
    }

    @Override
    public List<Book> findAllBooksAfterYear(int year) {
        return bookRepository.findAllByReleaseDateAfter(LocalDate.of(year, 12, 31));
    }

    @Override
    public List<String> getBooksByAuthorFirstNameAndLastName(String firstName, String lastName) {
        return bookRepository
                .findAllByAuthor_FirstNameAndAuthor_LastNameOrderByReleaseDateDescTitleAsc(firstName, lastName)
                .stream().map(book -> String.format("%s, release date: %s, copies: %d",
                        book.getTitle(),
                        book.getReleaseDate().toString(),
                        book.getCopies()))
                .collect(Collectors.toList());
    }

    private Book createBookFromTokens(String[] data) {
        Author author = authorService.getRandomAuthor();
        EditionType editionType = EditionType.values()[Integer.parseInt(data[0])];
        LocalDate releaseDate = LocalDate.parse(data[1],
                DateTimeFormatter.ofPattern("d/M/yyyy"));
        int copies = Integer.parseInt(data[2]);
        BigDecimal price = new BigDecimal(data[3]);
        AgeRestriction ageRestriction = AgeRestriction
                .values()[Integer.parseInt(data[4])];
        String title = Arrays.stream(data)
                .skip(5)
                .collect(Collectors.joining(" "));
        Set<Category> categories = categoryService.getRandomCategories();


        return new Book(title, editionType, price, copies, releaseDate,
                ageRestriction, author, categories);
    }
}
