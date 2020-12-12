import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class t_07_crossfire {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        String[] dimensions = reader.readLine().split("\\s+");
        
        int rowCount = Integer.parseInt(dimensions[0]);
        int colCount = Integer.parseInt(dimensions[1]);

        List<List<Integer>> matrix = new ArrayList<>();
        int value = 1;

        for (int row = 0; row < rowCount; row++) {
            matrix.add(new ArrayList<>());

            for (int col = 0; col < colCount; col++) {
                matrix.get(row).add(value++);
            }
        }
        
        String command;
        String[] commTokens;
        int targetRow;
        int targetCol;
        int range;
        while(!(command = reader.readLine()).equals("Nuke it from orbit")) {
            commTokens = command.split("\\s+");

            targetRow = Integer.parseInt(commTokens[0]);
            targetCol = Integer.parseInt(commTokens[1]);
            range = Integer.parseInt(commTokens[2]);

            Fire(matrix, targetRow, targetCol, range);
        }

        printMatrix(matrix);
    }

    private static void printMatrix(List<List<Integer>> matrix) {
        for (List<Integer> integers : matrix) {
            String result = integers.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(" "));

            System.out.println(result);
        }
    }

    private static void Fire(List<List<Integer>> matrix, int targetRow, int targetCol, int range) {
        //Up
        for (int row = targetRow - 1; row > targetRow - range - 1; row--) {
            destroyCell(matrix, row, targetCol);
        }

        //Down
        for (int row = targetRow + 1; row < targetRow + range + 1 ; row++) {
            destroyCell(matrix, row, targetCol);
        }

        //Same row right
        for (int col = targetCol + range; col > targetCol - 1; col--) {
            destroyCell(matrix, targetRow, col);
        }

        //Same row left
        for (int col = targetCol - 1; col > targetCol - range - 1; col--) {
            destroyCell(matrix, targetRow, col);
        }
    }

    private static void destroyCell(List<List<Integer>> matrix, int targetRow, int targetCol) {
        if (cellInMatrix(matrix, targetRow, targetCol)) {
            matrix.get(targetRow).remove(targetCol);
            if (matrix.get(targetRow).size() < 1) {
                matrix.remove(targetRow);
            }
        }
    }

    private static boolean cellInMatrix(List<List<Integer>> matrix, int targetRow, int targetCol) {
        return targetRow >= 0 && targetRow < matrix.size() && targetCol >= 0 && targetCol < matrix.get(targetRow).size();
    }
}
