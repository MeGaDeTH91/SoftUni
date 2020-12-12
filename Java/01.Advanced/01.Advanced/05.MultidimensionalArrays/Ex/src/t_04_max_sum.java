import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.stream.Collectors;

public class t_04_max_sum {
    private static final BufferedReader reader;
    private static final int[][] maxSumMatrix;
    private static int maxSum;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        maxSumMatrix = new int[3][3];
        maxSum = Integer.MIN_VALUE;
    }
    public static void main(String[] args) throws IOException {
        String[] matrixDimensions = reader.readLine().split("\\s+");
        int rowCount = Integer.parseInt(matrixDimensions[0]);
        int colCount = Integer.parseInt(matrixDimensions[1]);

        int[][] matrix = new int[rowCount][];

        for (int row = 0; row < rowCount; row++) {
            matrix[row] = Arrays.stream(reader.readLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        }

        int currentSum;

        int bestSumRow = 0;
        int bestSumCol = 0;

        for (int row = 0; row < rowCount - 2; row++) {
            for (int col = 0; col < colCount - 2; col++) {
                currentSum = calculateCurrentMatrixSum(matrix, row, col);

                if (currentSum > maxSum) {
                    maxSum = currentSum;
                    bestSumRow = row;
                    bestSumCol = col;
                }
            }
        }

        populateMaxSumMatrix(matrix, bestSumRow, bestSumCol);

        printResult();
    }

    private static void printResult() {

        System.out.printf("Sum = %d%n", maxSum);

        for (int row = 0; row < 3; row++) {
            String result = Arrays.stream(maxSumMatrix[row])
                    .mapToObj(String::valueOf)
                    .collect(Collectors.joining(" "));
            System.out.println(result);
        }
    }

    private static void populateMaxSumMatrix(int[][] matrix, int bestSumRow, int bestSumCol) {
        for (int row = bestSumRow; row < bestSumRow + 3; row++) {
            System.arraycopy(matrix[row], bestSumCol, maxSumMatrix[row - bestSumRow], 0, 3);
        }
    }

    private static int calculateCurrentMatrixSum(int[][] matrix, int startRow, int startCol) {
        int sum = 0;

        for (int row = startRow; row < startRow + 3; row++) {
            for (int col = startCol; col < startCol + 3; col++) {
                sum += matrix[row][col];
            }
        }

        return sum;
    }
}
