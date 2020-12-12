import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class t_02_snake {
    private static final BufferedReader reader;
    private static int snakeRow;
    private static int snakeCol;
    private static int snakeFoodEaten;
    private static int firstBurrowRow;
    private static int firstBurrowCol;
    private static int secondBurrowRow;
    private static int secondBurrowCol;
    private static boolean hasLair;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        hasLair = false;
    }

    public static void main(String[] args) throws IOException {
        int matrixSize = Integer.parseInt(reader.readLine());

        char[][] matrix = new char[matrixSize][];

        String currentLine;
        boolean snakeIsFound = false;
        for (int row = 0; row < matrixSize; row++) {
            currentLine = reader.readLine();
            matrix[row] = currentLine.toCharArray();

            if (!snakeIsFound && currentLine.contains("S")) {
                snakeRow = row;
                snakeCol = currentLine.indexOf('S');
                snakeIsFound = true;
            }

            if (currentLine.contains("B")) {
                if (hasLair) {
                    secondBurrowRow = row;
                    secondBurrowCol = currentLine.indexOf('B');
                } else {
                    firstBurrowRow = row;
                    firstBurrowCol = currentLine.indexOf('B');
                    hasLair = true;
                }
            }
        }

        String command;
        while (true) {
            command = reader.readLine();

            matrix[snakeRow][snakeCol] = '.';
            updateSnakeLocation(command);

            if (outOfMatrix(matrixSize)) {
                break;
            }

            checkCell(matrix);

            if (snakeIsFed()) {
                break;
            }
        }

        if (snakeFoodEaten >= 10) {
            System.out.println("You won! You fed the snake.");
        } else {
            System.out.println("Game over!");
        }

        System.out.printf("Food eaten: %d%n", snakeFoodEaten);

        printMatrix(matrix, matrixSize);
    }

    private static void printMatrix(char[][] matrix, int matrixSize) {
        for (int row = 0; row < matrixSize; row++) {
            System.out.println(new String(matrix[row]));
        }
    }

    private static void checkCell(char[][] matrix) {
        char currentCell = matrix[snakeRow][snakeCol];

        if (currentCell == '*') {
            snakeFoodEaten++;
        } else if (currentCell == 'B') {
            enterBurrow(matrix);
        }

        matrix[snakeRow][snakeCol] = 'S';
    }

    private static void enterBurrow(char[][] matrix) {
        matrix[snakeRow][snakeCol] = '.';
        if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol) {
            snakeRow = secondBurrowRow;
            snakeCol = secondBurrowCol;
        } else {
            snakeRow = firstBurrowRow;
            snakeCol = firstBurrowCol;
        }
    }

    private static void updateSnakeLocation(String command) {
        switch (command) {
            case "up":
                snakeRow--;
                break;
            case "down":
                snakeRow++;
                break;
            case "left":
                snakeCol--;
                break;
            case "right":
                snakeCol++;
                break;
            default:
                break;
        }
    }

    private static boolean outOfMatrix(int matrixSize) {
        return snakeRow < 0 || snakeRow >= matrixSize || snakeCol < 0 || snakeCol >= matrixSize;
    }

    private static boolean snakeIsFed() {
        return snakeFoodEaten >= 10;
    }
}
