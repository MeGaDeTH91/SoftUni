package com.example.football.util.impl;

import com.example.football.util.XmlParser;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class XmlParserImpl implements XmlParser {

    private JAXBContext jaxbContext;

    @Override
    @SuppressWarnings("unchecked")
    public<T> T readFromFile(String filePath, Class<T> tClass) {
        try {
            jaxbContext = JAXBContext.newInstance(tClass);
            Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();

            return (T)unmarshaller.unmarshal(new FileReader(filePath));
        } catch (Exception e) {
            System.out.println("There was problem reading from file " + filePath);
        }
        return null;
    }

    @Override
    public <T> void writeToFile(String filePath, T entity) throws JAXBException, IOException {
        jaxbContext = JAXBContext.newInstance(entity.getClass());
        Marshaller marshaller = jaxbContext.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);

        marshaller.marshal(entity, new FileWriter(filePath));
    }
}
