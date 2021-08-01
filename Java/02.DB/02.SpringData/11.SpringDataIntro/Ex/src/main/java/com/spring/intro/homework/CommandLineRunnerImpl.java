package com.spring.intro.homework;

import com.spring.intro.homework.models.entity.Author;
import com.spring.intro.homework.models.entity.Book;
import com.spring.intro.homework.services.interfaces.AuthorService;
import com.spring.intro.homework.services.interfaces.BookService;
import com.spring.intro.homework.services.interfaces.CategoryService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

@Component
public class CommandLineRunnerImpl implements CommandLineRunner {
    private final AuthorService authorService;
    private final BookService bookService;
    private final CategoryService categoryService;

    public CommandLineRunnerImpl(AuthorService authorService, BookService bookService, CategoryService categoryService) {
        this.authorService = authorService;
        this.bookService = bookService;
        this.categoryService = categoryService;
    }

    @Override
    public void run(String... args) throws Exception {
        seedDatabase();

        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        int taskNumber = Integer.parseInt(bufferedReader.readLine());

        switch (taskNumber){
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
            default:
                System.out.println("Please provide task number in the range 1-4");
                break;
        }
    }

    private void executeTaskFour() {
        bookService
                .getBooksByAuthorFirstNameAndLastName("George", "Powell")
                .forEach(System.out::println);
    }

    private void executeTaskThree() {
        authorService
                .getAuthorsOrderedByBooksCountDesc()
                .forEach(System.out::println);
    }

    private void executeTaskTwo() {
        bookService.findAllBooksBeforeYear(1990)
        .forEach(System.out::println);
    }

    private void executeTaskOne() {
        bookService.findAllBooksAfterYear(2000)
        .stream().map(Book::getTitle)
        .forEach(System.out::println);
    }

    private void seedDatabase() throws IOException {
        authorService.seedAuthors();
        categoryService.seedCategories();
        bookService.seedBooks();

        System.out.println("Initialized successfully!");
    }
}
