package com.spring.intro.homework.services.interfaces;

import com.spring.intro.homework.models.entity.Author;

import java.io.IOException;
import java.util.List;

public interface AuthorService {
    void seedAuthors() throws IOException;

    Author getRandomAuthor();

    List<String> getAuthorsOrderedByBooksCountDesc();
}
