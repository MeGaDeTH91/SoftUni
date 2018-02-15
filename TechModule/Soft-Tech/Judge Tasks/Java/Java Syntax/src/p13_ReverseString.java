import java.lang.reflect.Array;
import java.util.Scanner;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p13_ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        char[] arr = input.toCharArray();

        StringBuilder sb = new StringBuilder();
        for (int i = arr.length - 1; i >= 0; i--) {
            sb.append(arr[i]);

        }
        System.out.println(sb.toString());
    }
}
