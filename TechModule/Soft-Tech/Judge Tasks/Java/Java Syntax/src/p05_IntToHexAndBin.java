import java.util.Scanner;

/**
 * Created by Marto on 4.8.2017 г..
 */
public class p05_IntToHexAndBin {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());
        String hex = Integer.toHexString(num).toUpperCase();
        String binary = Integer.toBinaryString(num);
        System.out.println(hex);
        System.out.println(binary);
    }
}
