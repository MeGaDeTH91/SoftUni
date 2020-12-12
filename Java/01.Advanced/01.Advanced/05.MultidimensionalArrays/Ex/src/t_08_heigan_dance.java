import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Deque;

public class t_08_heigan_dance {
    private static BufferedReader reader;
    private static int[] playerLocation;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        playerLocation = new int[2];
        playerLocation[0] = 7;
        playerLocation[1] = 7;
    }

    public static void main(String[] args) throws IOException {
        double playerHealth = 18500.0d;
        double heiganHealth = 3_000_000.0d;

        Deque<String> spells = new ArrayDeque<>();

        double playerDamage = Double.parseDouble(reader.readLine());
        String lastSpell = "";

        String[] currentTokens;
        String currentCastedSpell;
        int currentCastedRow;
        int currentCastedCol;
        while (playerHealth > 0 && heiganHealth > 0) {
            heiganHealth -= playerDamage;
            if (spells.size() > 0) {
                lastSpell = spells.pop();

                playerHealth -= 3500;

                if (playerHealth <= 0) {
                    continue;
                }
            }

            if (heiganHealth <= 0) {
                continue;
            }

            currentTokens = reader.readLine().split("\\s+");

            currentCastedSpell = currentTokens[0];
            currentCastedRow = Integer.parseInt(currentTokens[1]);
            currentCastedCol = Integer.parseInt(currentTokens[2]);

            if (hasToEvade(currentCastedRow, currentCastedCol, playerLocation[0], playerLocation[1]) && !canEvade(currentCastedRow, currentCastedCol, playerLocation[0], playerLocation[1])) {
                if (currentCastedSpell.equals("Cloud")) {
                    lastSpell = "Plague Cloud";
                    playerHealth -= 3500;

                    spells.push("Plague Cloud");
                } else if (currentCastedSpell.equals("Eruption")) {
                    lastSpell = "Eruption";

                    playerHealth -= 6000;
                }
            }
        }

        String heiganResult = heiganHealth > 0 ? String.format("%.2f", heiganHealth) : "Defeated!";
        String playerResult = playerHealth > 0 ? String.format("%.0f", playerHealth) : String.format("Killed by %s", lastSpell);

        System.out.printf("Heigan: %s%n", heiganResult);
        System.out.printf("Player: %s%n", playerResult);
        System.out.printf("Final position: %d, %d%n", playerLocation[0], playerLocation[1]);
    }

    private static boolean canEvade(int currentCastedRow, int currentCastedCol, int playerRow, int playerCol) {
        boolean playerCanEvade = false;
        // Check up
        if (cellIsInChamber(playerRow - 1, playerCol) && !hasToEvade(currentCastedRow, currentCastedCol, playerRow - 1, playerCol)) {
            playerLocation[0] = playerRow - 1;
            playerCanEvade = true;
        } else if (cellIsInChamber(playerRow, playerCol + 1) && !hasToEvade(currentCastedRow, currentCastedCol, playerRow, playerCol + 1)) {
            playerLocation[1] = playerCol + 1;
            playerCanEvade = true;
        } else if (cellIsInChamber(playerRow + 1, playerCol) && !hasToEvade(currentCastedRow, currentCastedCol, playerRow + 1, playerCol)) {
            playerLocation[0] = playerRow + 1;
            playerCanEvade = true;
        } else if (cellIsInChamber(playerRow, playerCol - 1) && !hasToEvade(currentCastedRow, currentCastedCol, playerRow, playerCol - 1)) {
            playerLocation[1] = playerCol - 1;
            playerCanEvade = true;
        }

        return playerCanEvade;
    }

    private static boolean hasToEvade(int currentCastedRow, int currentCastedCol, int playerRow, int playerCol) {
        boolean upperLeft = currentCastedRow - 1 == playerRow && currentCastedCol - 1 == playerCol;
        boolean upper = currentCastedRow - 1 == playerRow && currentCastedCol == playerCol;
        boolean upperRight = currentCastedRow - 1 == playerRow && currentCastedCol + 1 == playerCol;
        boolean left = currentCastedRow == playerRow && currentCastedCol - 1 == playerCol;
        boolean center = currentCastedRow == playerRow && currentCastedCol == playerCol;
        boolean right = currentCastedRow == playerRow && currentCastedCol + 1 == playerCol;
        boolean bottomLeft = currentCastedRow + 1 == playerRow && currentCastedCol - 1 == playerCol;
        boolean bottom = currentCastedRow + 1 == playerRow && currentCastedCol == playerCol;
        boolean bottomRight = currentCastedRow + 1 == playerRow && currentCastedCol + 1 == playerCol;

        return upperLeft || upper || upperRight || left || center || right || bottomLeft || bottom || bottomRight;
    }

    private static boolean cellIsInChamber(int row, int col) {
        return row >= 0 && row < 15 && col >= 0 && col < 15;
    }
}
