import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.stream.Collectors;

public class t_01_fill_matrix {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String[] tokens = reader.readLine().split(", ");

        int dimensions = Integer.parseInt(tokens[0]);
        String type = tokens[1];

        int[][] matrix = new int[dimensions][dimensions];

        fillMatrix(matrix, dimensions, type);

        printMatrix(matrix, dimensions);
    }

    private static void printMatrix(int[][] matrix, int dimensions) {
        for (int row = 0; row < dimensions; row++) {
            String result = Arrays.stream(matrix[row])
                    .mapToObj(String::valueOf)
                    .collect(Collectors.joining(" "));
            System.out.println(result);
        }
    }

    private static void fillMatrix(int[][] matrix, int dimensions, String type) {
        int counter = 1;

        if ("A".equals(type)) {
            for (int col = 0; col < dimensions; col++) {
                for (int row = 0; row < dimensions; row++) {
                    matrix[row][col] = counter++;
                }
            }
        } else if ("B".equals(type)){
            for (int col = 0; col < dimensions; col++) {
                if (col % 2 == 0) {
                    for (int row = 0; row < dimensions; row++) {
                        matrix[row][col] = counter++;
                    }
                } else {
                    for (int row = dimensions - 1; row >= 0; row--) {
                        matrix[row][col] = counter++;
                    }
                }
            }
        }
    }
}
