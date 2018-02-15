import java.util.Scanner;

/**
 * Created by Marto on 6.8.2017 г..
 */
public class p10_IndexofLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        char[] arr = input.toCharArray();

        for (int i = 0; i < arr.length; i++) {
            char current = arr[i];
            int currAsc = (int)current - 97;

            System.out.println(current + " -> " + currAsc);

        }
    }
}
