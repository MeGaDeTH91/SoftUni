package t_01_card_suit;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        reader.readLine();
        System.out.println("Card Suits:");

        for (SuitType currType: SuitType.values()) {
            System.out.printf("Ordinal value: %d; Name value: %s%n", currType.ordinal(), currType);
        }
    }
}
