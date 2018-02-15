import java.util.Scanner;

public class p01_VariableInHex {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        int num = Integer.parseInt(input, 16);
        System.out.println(num);
    }
}
