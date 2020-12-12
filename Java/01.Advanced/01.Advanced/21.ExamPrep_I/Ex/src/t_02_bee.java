import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class t_02_bee {
    private static final BufferedReader reader;
    private static int pollinatedFlowers;
    private static int beeRow;
    private static int beeCol;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        pollinatedFlowers = 0;
        beeRow = 0;
        beeCol = 0;
    }

    public static void main(String[] args) throws IOException {
        int squareSize = Integer.parseInt(reader.readLine());
        char[][] matrix = new char[squareSize][squareSize];

        String matrixInputLine;
        for (int row = 0; row < squareSize; row++) {
            matrix[row] = reader.readLine().toCharArray();
            matrixInputLine = new String(matrix[row]);

            if (matrixInputLine.contains("B")) {
                beeRow = row;
                beeCol = matrixInputLine.indexOf('B');
            }
        }

        boolean outOfMatrix = false;
        String command;
        while (!(command = reader.readLine()).equals("End")) {
            matrix[beeRow][beeCol] = '.';
            outOfMatrix = updateBeePosition(command, squareSize);
            if (outOfMatrix) {
                break;
            }

            checkCell(matrix, squareSize, command);
        }

        if (outOfMatrix) {
            System.out.println("The bee got lost!");
        }

        if (pollinatedFlowers >= 5) {
            System.out.printf("Great job, the bee manage to pollinate %d flowers!%n", pollinatedFlowers);
        } else {
            System.out.printf("The bee couldn't pollinate the flowers, she needed %d flowers more%n", 5 - pollinatedFlowers);
        }

        printMatrix(matrix, squareSize);
    }

    private static void printMatrix(char[][] matrix, int squareSize) {
        for (int row = 0; row < squareSize; row++) {
            System.out.println(String.join("", new String(matrix[row])));
        }
    }

    private static void checkCell(char[][] matrix, int squareSize, String direction) {
        switch (matrix[beeRow][beeCol]) {
            case 'f':
                pollinatedFlowers++;
                matrix[beeRow][beeCol] = '.';
                break;
            case 'O':
                matrix[beeRow][beeCol] = '.';
                updateBeePosition(direction, squareSize);
                checkCell(matrix, squareSize, direction);
                break;
            default:
                break;
        }
        matrix[beeRow][beeCol] = 'B';
    }

    private static boolean updateBeePosition(String direction, int squareSize) {
        switch (direction) {
            case "up":
                beeRow--;
                break;
            case "down":
                beeRow++;
                break;
            case "left":
                beeCol--;
                break;
            case "right":
                beeCol++;
                break;
            default:
                break;
        }

        return beeRow < 0 || beeRow >= squareSize || beeCol < 0 || beeCol >= squareSize;
    }
}
