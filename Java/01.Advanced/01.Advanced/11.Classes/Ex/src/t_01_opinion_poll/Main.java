package t_01_opinion_poll;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int rowsCount = Integer.parseInt(reader.readLine());

        List<Person> people = new ArrayList<>();

        String[] commTokens;
        String name;
        int age;
        Person person;
        for (int i = 0; i < rowsCount; i++) {
            commTokens = reader.readLine().split("\\s+");
            name = commTokens[0];
            age = Integer.parseInt(commTokens[1]);

            person = new Person(name, age);
            people.add(person);
        }

        people = people.stream().filter(x -> x.age > 30).collect(Collectors.toList());
        Collections.sort(people);

        people.forEach(x -> System.out.printf("%s - %d%n", x.name, x.age));
    }
}
