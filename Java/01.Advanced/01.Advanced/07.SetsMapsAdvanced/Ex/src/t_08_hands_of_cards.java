import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class t_08_hands_of_cards {
    private static final BufferedReader reader;
    private static final Map<String, Integer> cards;
    private static final Map<String, Integer> cardTypes;
    private static final Map<String, Set<String>> players;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        cards = new HashMap<>(15);
        cardTypes = new HashMap<>(5);
        players = new LinkedHashMap<>();
        fillCards();
    }

    public static void main(String[] args) throws IOException {
        String line;
        String[] lineTokens;
        String player;
        String[] currentCards;
        while (!(line = reader.readLine()).equals("JOKER")) {
            lineTokens = line.split(":");

            player = lineTokens[0];
            currentCards = lineTokens[1].trim().split("[,\\s]+");

            if (!players.containsKey(player)) {
                players.put(player, new HashSet<>());
            }

            players.get(player).addAll(Arrays.asList(currentCards));
        }

        int total;
        for (Map.Entry<String, Set<String>> playerPairs: players.entrySet()) {
            total = 0;

            for (String card: playerPairs.getValue()) {
                total += calculateCard(card);
            }

            System.out.printf("%s: %d%n", playerPairs.getKey(), total);
        }
    }

    private static int calculateCard(String card) {
        int points;

        if (card.length() == 2) {
            points = cards.get(String.valueOf(card.charAt(0))) * cardTypes.get(String.valueOf(card.charAt(1)));
        } else {
            points = cards.get(card.substring(0, 2)) * cardTypes.get(String.valueOf(card.charAt(2)));
        }

        return points;
    }

    private static void fillCards() {
        cards.put("2", 2);
        cards.put("3", 3);
        cards.put("4", 4);
        cards.put("5", 5);
        cards.put("6", 6);
        cards.put("7", 7);
        cards.put("8", 8);
        cards.put("9", 9);
        cards.put("10", 10);
        cards.put("J", 11);
        cards.put("Q", 12);
        cards.put("K", 13);
        cards.put("A", 14);

        cardTypes.put("S", 4);
        cardTypes.put("H", 3);
        cardTypes.put("D", 2);
        cardTypes.put("C", 1);
    }
}
