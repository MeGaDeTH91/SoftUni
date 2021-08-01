package com.example.springintro;

import com.example.springintro.model.entity.AgeRestriction;
import com.example.springintro.model.entity.EditionType;
import com.example.springintro.service.AuthorService;
import com.example.springintro.service.BookService;
import com.example.springintro.service.CategoryService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

@Component
public class CommandLineRunnerImpl implements CommandLineRunner {

    private final CategoryService categoryService;
    private final AuthorService authorService;
    private final BookService bookService;
    private final BufferedReader bufferedReader;

    private final Map<String, AgeRestriction> ageRestrictions;

    public CommandLineRunnerImpl(CategoryService categoryService, AuthorService authorService, BookService bookService) {
        this.categoryService = categoryService;
        this.authorService = authorService;
        this.bookService = bookService;
        this.bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, AgeRestriction> restrictionMap = new HashMap<>();
        for (AgeRestriction instance : AgeRestriction.values()) {
            restrictionMap.put(instance.name(), instance);
        }

        ageRestrictions = Collections.unmodifiableMap(restrictionMap);
    }

    @Override
    public void run(String... args) throws Exception {
        seedData();

        System.out.print("Enter task number: ");
        int taskNumber = Integer.parseInt(bufferedReader.readLine());

        switch (taskNumber) {
            case 1:
                executeTaskOne();
                break;
            case 2:
                executeTaskTwo();
                break;
            case 3:
                executeTaskThree();
                break;
            case 4:
                executeTaskFour();
                break;
            case 5:
                executeTaskFive();
                break;
            case 6:
                executeTaskSix();
                break;
            case 7:
                executeTaskSeven();
                break;
            case 8:
                executeTaskEight();
                break;
            case 9:
                executeTaskNine();
                break;
            case 10:
                executeTaskTen();
                break;
            case 11:
                executeTaskEleven();
                break;
            case 12:
                executeTaskTwelve();
                break;
            default:
                break;
        }
    }

    private void executeTaskTwelve() throws IOException {
        System.out.print("Enter release date in the format 'dd MMM yyyy': ");
        String targetRelease = bufferedReader.readLine();
        DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMM yyyy");
        LocalDate localDate = LocalDate.parse(targetRelease, dateFormat);

        System.out.print("Enter copies to add number: ");
        int addCopiesNumber = Integer.parseInt(bufferedReader.readLine());

        var booksUpdated = bookService.updateCopiesOfBooksByReleaseDate(localDate, addCopiesNumber) * addCopiesNumber;

        System.out.println(booksUpdated);
    }

    private void executeTaskEleven() throws IOException {
        System.out.print("Enter book title: ");
        String bookTitle = bufferedReader.readLine();

        System.out.println(bookService.getSpecificBookDetailsByBookTitle(bookTitle));
    }

    private void executeTaskTen() {
        authorService.getAllAuthorsWithTotalNumberOfCopiesDesc().forEach(System.out::println);
    }

    private void executeTaskNine() throws IOException {
        System.out.print("Enter title target length: ");
        int titleLength = Integer.parseInt(bufferedReader.readLine());

        System.out.println(bookService.getBooksCountWithTitleLengthGreaterThan(titleLength));
    }

    private void executeTaskEight() throws IOException {
        System.out.print("Enter first part of author's last name: ");
        String authorLastNamePart = bufferedReader.readLine();

        bookService
                .findAllByAuthorLastNameStartsWith(authorLastNamePart)
                .forEach(System.out::println);
    }

    private void executeTaskSeven() throws IOException {
        System.out.print("Enter part of book's title: ");
        String bookTitlePart = bufferedReader.readLine();

        bookService
                .findAllBooksWithTitleContains(bookTitlePart)
                .forEach(System.out::println);
    }

    private void executeTaskSix() throws IOException {
        System.out.print("Enter last part of author's first name: ");
        String strEndsWith = bufferedReader.readLine();

        authorService
                .getAllAuthorsThatFirstNameEndsWith(strEndsWith)
                .forEach(System.out::println);
    }

    private void executeTaskFive() throws IOException {
        System.out.print("Enter release date in the format 'dd-MM-yyyy': ");
        String release = bufferedReader.readLine();
        DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd-MM-yyyy");
        LocalDate localDate = LocalDate.parse(release, dateFormat);

        bookService
                .findAllBooksBeforeDate(localDate)
                .forEach(System.out::println);
    }

    private void executeTaskFour() throws IOException {
        System.out.print("Enter year of release: ");
        int year = Integer.parseInt(bufferedReader.readLine());

        bookService
                .findAllBooksWithReleaseYearNotEqualTo(year)
                .forEach(System.out::println);
    }

    private void executeTaskThree() {
        bookService
                .findAllBooksByPriceBoundaries(BigDecimal.valueOf(5), BigDecimal.valueOf(40))
                .forEach(System.out::println);
    }

    private void executeTaskTwo() {
        EditionType editionType = EditionType.valueOf("GOLD");

        bookService
                .findAllBooksByEditionTypeAndCopiesLessThan(editionType, 5000)
                .forEach(System.out::println);
    }

    private void executeTaskOne() throws IOException {
        System.out.print("Enter age restriction: ");
        String ageRestrictionStr = bufferedReader.readLine().toUpperCase();
        AgeRestriction ageRestriction = ageRestrictions.get(ageRestrictionStr);
        if (ageRestriction == null) {
            System.out.println("Please provide valid age restriction.");
        } else {
            bookService
                    .findAllBooksByAgeRestriction(ageRestriction)
                    .forEach(System.out::println);
        }
    }

    private void seedData() throws IOException {
        categoryService.seedCategories();
        authorService.seedAuthors();
        bookService.seedBooks();
    }
}
