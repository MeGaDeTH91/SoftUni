package t_02_animal_farm;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        String name = reader.readLine();
        int age = Integer.parseInt(reader.readLine());

        try {
            Chicken chicken = new Chicken(name, age);

            System.out.println(chicken.toString());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
