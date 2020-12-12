package t_03_cards_with_power;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        String targetRank = reader.readLine();
        String targetSuit = reader.readLine();

        int sum = CardRank.valueOf(targetRank).getValue() + CardSuit.valueOf(targetSuit).getValue();

        System.out.printf("Card name: %s of %s; Card power: %d", targetRank, targetSuit, sum);
    }
}
