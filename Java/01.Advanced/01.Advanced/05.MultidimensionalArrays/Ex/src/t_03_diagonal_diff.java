import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

public class t_03_diagonal_diff {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int dimension = Integer.parseInt(reader.readLine());

        int[][] matrix = new int[dimension][];

        for (int row = 0; row < dimension; row++) {
            matrix[row] = Arrays.stream(reader.readLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        }

        int leftDiagonal = 0;
        int rightDiagonal = 0;

        for (int row = 0; row < dimension; row++) {
            leftDiagonal += matrix[row][row];
        }

        int col;

        for (int row = 0; row < dimension; row++) {
            col = dimension - row - 1;
            rightDiagonal += matrix[row][col];
        }

        int diff = Math.abs(leftDiagonal - rightDiagonal);

        System.out.println(diff);
    }
}
