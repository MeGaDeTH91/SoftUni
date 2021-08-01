package com.spring.intro.homework.services.interfaces;

import com.spring.intro.homework.models.entity.Book;

import java.io.IOException;
import java.util.List;

public interface BookService {
    void seedBooks() throws IOException;

    List<String> findAllBooksBeforeYear(int i);

    List<Book> findAllBooksAfterYear(int i);

    List<String> getBooksByAuthorFirstNameAndLastName(String firstName, String lastName);
}
