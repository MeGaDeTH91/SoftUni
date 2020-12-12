import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.stream.Collectors;

public class t_05_matrix_shuffling {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        String[] dimensionTokens = reader.readLine().split("\\s+");
        int rowCount = Integer.parseInt(dimensionTokens[0]);
        int colCount = Integer.parseInt(dimensionTokens[1]);

        String[][] matrix = new String[rowCount][];

        for (int row = 0; row < rowCount; row++) {
            matrix[row] = reader.readLine().split("\\s+");
        }

        String line;
        String[] commTokens;
        String command;

        int sourceRow;
        int sourceCol;
        int destRow;
        int destCol;

        String tempElement;
        while (!(line = reader.readLine()).equals("END")) {
            try {
                commTokens = line.split("\\s+");

                command = commTokens[0];
                sourceRow = Integer.parseInt(commTokens[1]);
                sourceCol = Integer.parseInt(commTokens[2]);
                destRow = Integer.parseInt(commTokens[3]);
                destCol = Integer.parseInt(commTokens[4]);

                if (commTokens.length != 5 || !"swap".equals(command)) {
                    throw new IllegalArgumentException();
                }

                tempElement = matrix[sourceRow][sourceCol];
                matrix[sourceRow][sourceCol] = matrix[destRow][destCol];
                matrix[destRow][destCol] = tempElement;

                printMatrix(matrix, rowCount);
            } catch (Exception e) {
                System.out.println("Invalid input!");
            }
        }
    }

    private static void printMatrix(String[][] matrix, int rowCount) {
        for (int row = 0; row < rowCount; row++) {
            System.out.println(String.join(" ", matrix[row]));
        }
    }
}
