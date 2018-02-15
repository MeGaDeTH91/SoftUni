import java.util.Scanner;

/**
 * Created by Marto on 4.8.2017 г..
 */
public class p03_ReverseChars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String a = scanner.nextLine();
        String b = scanner.nextLine();
        String c = scanner.nextLine();

        String result = c+b+a;
        System.out.println(result);
    }
}
