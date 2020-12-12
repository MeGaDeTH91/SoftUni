import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.stream.Collectors;

public class t_02_garden {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int[] gardenDimensions = Arrays.stream(reader.readLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int cellCount = gardenDimensions[0];

        int[][] garden = new int[cellCount][cellCount];
        boolean[][] onlyPlants = new boolean[cellCount][cellCount];

        int[] currentCell;
        int plantRow;
        int plantCol;
        String command;
        while (!(command = reader.readLine()).equals("Bloom Bloom Plow")) {
            currentCell = Arrays.stream(command.split(" ")).mapToInt(Integer::parseInt).toArray();
            plantRow = currentCell[0];
            plantCol = currentCell[1];

            if (invalidCoordinates(plantRow, plantCol, cellCount)) {
                System.out.println("Invalid coordinates.");
            } else {
                onlyPlants[plantRow][plantCol] = true;
            }
        }

        for (int row = 0; row < cellCount; row++) {
            for (int col = 0; col < cellCount; col++) {
                if (onlyPlants[row][col]) {
                    markCells(garden, row, col, cellCount);
                }
            }
        }

        printGarden(garden, cellCount);
    }

    private static void printGarden(int[][] garden, int cellCount) {
        for (int row = 0; row < cellCount; row++) {
            String result = Arrays.stream(garden[row])
                    .mapToObj(String::valueOf)
                    .collect(Collectors.joining(" "));

            System.out.println(result);
        }
    }

    private static void markCells(int[][] garden, int row, int col, int cellCount) {
        int currentRow = row;

        while (currentRow >= 0) {
            garden[currentRow][col]++;
            currentRow--;
        }

        currentRow = row + 1;
        while (currentRow < cellCount) {
            garden[currentRow][col]++;
            currentRow++;
        }

        int currentCol = col - 1;
        while (currentCol >= 0) {
            garden[row][currentCol]++;
            currentCol--;
        }

        currentCol = col + 1;
        while (currentCol < cellCount) {
            garden[row][currentCol]++;
            currentCol++;
        }
    }

    private static boolean invalidCoordinates(int plantRow, int plantCol, int cellCount) {
        return plantRow < 0 || plantRow >= cellCount || plantCol < 0 || plantCol >= cellCount;
    }
}
