package t_05_telephony;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        List<String> numbers = List.of(reader.readLine().split("\\s+"));
        List<String> urls = List.of(reader.readLine().split("\\s+"));

        Smartphone smartphone = new Smartphone(numbers, urls);

        System.out.println(smartphone.toString());
    }
}
