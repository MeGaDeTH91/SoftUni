package com.spring.intro.homework.services.impl;

import com.spring.intro.homework.models.entity.Author;
import com.spring.intro.homework.repositories.AuthorRepository;
import com.spring.intro.homework.services.interfaces.AuthorService;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.Collectors;

@Service
public class AuthorServiceImpl implements AuthorService {

    private static final String AUTHORS_FILE_PATH = "src/main/resources/files/authors.txt";

    private final AuthorRepository authorRepository;

    public AuthorServiceImpl(AuthorRepository authorRepository) {
        this.authorRepository = authorRepository;
    }


    @Override
    public void seedAuthors() throws IOException {
        if(authorRepository.count() < 1) {
            Files.readAllLines(Path.of(AUTHORS_FILE_PATH))
                    .stream()
                    .filter(author -> !author.isEmpty())
                    .forEach(row -> {
                        String[] rowTokens = row.split("\\s+");
                        Author author;
                        if (rowTokens.length > 1) {
                            author = new Author(rowTokens[0], rowTokens[1]);
                        } else {
                            author = new Author(rowTokens[0]);
                        }

                        authorRepository.save(author);
                    });
        }
    }

    @Override
    public Author getRandomAuthor() {
        long randomId = ThreadLocalRandom
                .current()
                .nextLong(1, authorRepository.count() + 1);

        return authorRepository.findById(randomId)
                .orElse(null);
    }

    @Override
    public List<String> getAuthorsOrderedByBooksCountDesc() {
        return authorRepository.findAuthorByBooksSizeDescending()
                .stream().map(author -> {
                    if(author.getFirstName() != null) {
                        return String.format("%s %s, books count: %d",
                                author.getFirstName(),author.getLastName(),
                                author.getBooks().size());
                    } else {
                        return String.format("%s, books count: %d",
                                author.getLastName(),
                                author.getBooks().size());
                    }
                }).collect(Collectors.toList());
    }
}
