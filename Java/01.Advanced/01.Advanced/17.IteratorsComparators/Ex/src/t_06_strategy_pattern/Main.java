package t_06_strategy_pattern;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Set;
import java.util.TreeSet;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Set<Person> sortedByName = new TreeSet<>(new ComparatorName());
        Set<Person> sortedByAge = new TreeSet<>(new ComparatorAge());

        int linesCount = Integer.parseInt(reader.readLine());

        String[] tokens;
        String name;
        int age;
        Person person;
        for (int i = 0; i < linesCount; i++) {
            tokens = reader.readLine().split("\\s+");
            name = tokens[0];
            age = Integer.parseInt(tokens[1]);

            person = new Person(name, age);
            sortedByName.add(person);
            sortedByAge.add(person);
        }

        for (Person currPerson: sortedByName) {
            System.out.println(currPerson.toString());
        }

        for (Person currPerson: sortedByAge) {
            System.out.println(currPerson.toString());
        }
    }
}
