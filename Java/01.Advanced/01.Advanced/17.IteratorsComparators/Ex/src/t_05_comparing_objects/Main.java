package t_05_comparing_objects;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        List<Person> people = new ArrayList<>();

        String command;
        String[] tokens;
        String name;
        int age;
        String town;
        Person person;
        while(!(command = reader.readLine()).equals("END")) {
            tokens = command.split("\\s+");
            name = tokens[0];
            age = Integer.parseInt(tokens[1]);
            town = tokens[2];

            person = new Person(name, age, town);

            people.add(person);
        }

        int targetPerson = Integer.parseInt(reader.readLine());

        if (targetPerson >= people.size()) {
            System.out.println("No matches");
        } else {
            int equalPeople = 0;
            int notEqualPeople = 0;

            person = people.get(targetPerson);

            for (Person currPerson: people) {
                if (currPerson.compareTo(person) == 0) {
                    equalPeople++;
                } else {
                    notEqualPeople++;
                }
            }

            System.out.printf("%d %d %d%n", equalPeople, notEqualPeople, people.size());
        }
    }
}
