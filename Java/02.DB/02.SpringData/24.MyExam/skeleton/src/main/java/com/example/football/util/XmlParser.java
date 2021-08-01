package com.example.football.util;

import javax.xml.bind.JAXBException;
import java.io.IOException;

public interface XmlParser {
    <T> T readFromFile(String filePath, Class<T> tClass);

    <T> void writeToFile(String filePath, T entity) throws JAXBException, IOException;
}
