package t_05_jedi_galaxy;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] galaxyDimensions = Arrays.stream(scanner.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        int rowCount = galaxyDimensions[0];
        int colCount = galaxyDimensions[1];

        int[][] galaxy = new int[rowCount][colCount];

        int cellValue = 0;
        for (int row = 0; row < rowCount; row++) {
            for (int col = 0; col < colCount; col++) {
                galaxy[row][col] = cellValue++;
            }
        }

        String command;
        long sum = 0;
        int[] ivoS;
        int[] evil;
        while (!(command = scanner.nextLine()).equals("Let the Force be with you")) {
            ivoS = Arrays.stream(command.split("\\s+")).mapToInt(Integer::parseInt).toArray();
            evil = Arrays.stream(scanner.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
            int evilRow = evil[0];
            int evilCol = evil[1];

            while (evilRow >= 0 && evilCol >= 0) {
                if (evilRow < rowCount && evilCol < colCount) {
                    galaxy[evilRow][evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }

            int ivoRow = ivoS[0];
            int ivoCol = ivoS[1];

            while (ivoRow >= 0 && ivoCol < colCount) {
                if (ivoRow < rowCount && ivoCol >= 0) {
                    sum += galaxy[ivoRow][ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        System.out.println(sum);
    }
}
