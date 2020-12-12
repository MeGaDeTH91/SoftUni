package t_07_google;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {

    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, Person> people = new LinkedHashMap<>();

        String command;
        String[] tokens;
        String personName;
        String addElement;
        String elementName;
        String elementSecondaryParam;
        double salary;
        int carSpeed;
        Company company;
        Car car;
        Pokemon pokemon;
        Parent parent;
        Child child;
        while (!(command = reader.readLine()).equals("End")) {
            tokens = command.split("\\s+");

            personName = tokens[0];
            addElement = tokens[1];
            elementName = tokens[2];

            if (!people.containsKey(personName)) {
                people.put(personName, new Person(personName));
            }

            switch (addElement) {
                case "company":
                    elementSecondaryParam = tokens[3];
                    salary = Double.parseDouble(tokens[4]);
                    company = new Company(elementName, elementSecondaryParam, salary);

                    people.get(personName).setCompany(company);
                    break;
                case "car":
                    carSpeed = Integer.parseInt(tokens[3]);
                    car = new Car(elementName, carSpeed);

                    people.get(personName).setCar(car);
                    break;
                case "pokemon":
                    elementSecondaryParam = tokens[3];
                    pokemon = new Pokemon(elementName, elementSecondaryParam);

                    people.get(personName).addPokemon(pokemon);
                    break;
                case "parents":
                    elementSecondaryParam = tokens[3];
                    parent = new Parent(elementName, elementSecondaryParam);

                    people.get(personName).addParent(parent);
                    break;
                case "children":
                    elementSecondaryParam = tokens[3];
                    child = new Child(elementName, elementSecondaryParam);

                    people.get(personName).addChild(child);
                    break;
                default:
                    break;
            }
        }

        command = reader.readLine();

        System.out.print(people.get(command).toString());
    }
}
