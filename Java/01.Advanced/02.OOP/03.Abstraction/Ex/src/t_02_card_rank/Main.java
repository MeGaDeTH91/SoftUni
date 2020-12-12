package t_02_card_rank;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) {
        System.out.println("Card Ranks:");

        for (CardRank rank: CardRank.values()) {
            System.out.printf("Ordinal value: %d; Name value: %s%n", rank.ordinal(), rank);
        }
    }
}
