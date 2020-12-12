import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class t_02_matrix_of_palindromes {
    private static final BufferedReader reader;
    private static final StringBuilder text;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        text = new StringBuilder(5);
    }

    public static void main(String[] args) throws IOException {
        String[] tokens = reader.readLine().split("\\s+");

        int rowCount = Integer.parseInt(tokens[0]);
        int colCount = Integer.parseInt(tokens[1]);

        String[][] matrix = new String[rowCount][colCount];

        fillMatrix(matrix, rowCount, colCount);

        printMatrix(matrix,rowCount);
    }

    private static void printMatrix(String[][] matrix, int rowCount) {
        for (int row = 0; row < rowCount; row++) {
            System.out.println(String.join(" ", matrix[row]));
        }
    }

    private static void fillMatrix(String[][] matrix, int rowCount, int colCount) {
        char rowChar;
        char colChar;
        for (int row = 0; row < rowCount; row++) {
            rowChar = (char)(row + 'a');

            for (int col = 0; col < colCount; col++) {
                text.delete(0, text.length());
                colChar = (char)(col + rowChar);
                text.append(rowChar).append(colChar).append(rowChar);
                matrix[row][col] = text.toString();
            }
        }
    }
}
