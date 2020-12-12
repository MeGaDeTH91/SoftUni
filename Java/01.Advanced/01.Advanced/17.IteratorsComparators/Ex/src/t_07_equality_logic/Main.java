package t_07_equality_logic;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Set;
import java.util.TreeSet;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Set<Person> treeSetCollection = new TreeSet<>();
        Set<Person> hashSetCollection = new HashSet<>();

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
            treeSetCollection.add(person);
            hashSetCollection.add(person);
        }

        System.out.println(treeSetCollection.size());
        System.out.println(hashSetCollection.size());
    }
}
