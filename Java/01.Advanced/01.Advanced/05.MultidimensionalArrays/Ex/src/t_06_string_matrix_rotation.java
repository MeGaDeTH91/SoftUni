import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class t_06_string_matrix_rotation {
    private static final BufferedReader reader;
    private static final List<String> lines;
    private static final StringBuilder sb;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        lines = new ArrayList<>(8);
        sb = new StringBuilder(20);
    }

    public static void main(String[] args) throws IOException {
        String degreesLine = reader.readLine();

        String[] degreeTokens = degreesLine.split("[()]+");

        int degrees = Integer.parseInt(degreeTokens[1]) % 360;
        int maxColCount = Integer.MIN_VALUE;

        String line;
        int lineLength;
        while (!(line = reader.readLine()).equals("END")) {
            lines.add(line);

            lineLength = line.length();
            if (lineLength > maxColCount) {
                maxColCount = lineLength;
            }
        }

        int initialRowCount = lines.size();
        char[][] matrix = new char[initialRowCount][maxColCount];

        String currentWord;
        for (int row = 0; row < initialRowCount; row++) {
            currentWord = lines.get(row);

            for (int col = 0; col < currentWord.length(); col++) {
                matrix[row][col] = currentWord.charAt(col);
            }
        }

        printMatrix(matrix, degrees, initialRowCount, maxColCount);
    }

    private static void printMatrix(char[][] matrix, int degrees, int rowCount, int colCount) {
        System.out.println();
        if (degrees == 0) {
            for (int row = 0; row < rowCount; row++) {
                sb.delete(0, sb.length());

                for (int col = 0; col < colCount; col++) {
                    sb.append(matrix[row][col]);
                }
                System.out.println(sb.toString());
            }
        } else if (degrees == 90) {
            for (int col = 0; col < colCount; col++) {
                sb.delete(0, sb.length());

                for (int row = rowCount - 1; row >= 0; row--) {
                    char currentChar = matrix[row][col];

                    if (currentChar == '\u0000') {
                        currentChar = ' ';
                    }
                    sb.append(currentChar);
                }

                System.out.println(sb.toString());
            }


        } else if (degrees == 180) {
            for (int row = rowCount - 1; row >= 0; row--) {
                sb.delete(0, sb.length());

                for (int col = colCount - 1; col >= 0; col--) {
                    char currentChar = matrix[row][col];

                    if (currentChar == '\u0000') {
                        currentChar = ' ';
                    }
                    sb.append(currentChar);
                }
                System.out.println(sb.toString());
            }
        } else if (degrees == 270) {
            for (int col = colCount - 1; col >= 0 ; col--) {
                sb.delete(0, sb.length());

                for (int row = 0; row < rowCount; row++) {
                    char currentChar = matrix[row][col];

                    if (currentChar == '\u0000') {
                        currentChar = ' ';
                    }
                    sb.append(currentChar);
                }

                System.out.println(sb.toString());
            }
        }
    }
}
