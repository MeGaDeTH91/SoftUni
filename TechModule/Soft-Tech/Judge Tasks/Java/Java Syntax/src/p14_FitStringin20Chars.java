import java.util.Scanner;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p14_FitStringin20Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        char[] arr = input.toCharArray();

        if(input.length() < 20){
            int diff = 20 - input.length();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < diff; i++) {
                sb.append('*');
            }
            System.out.println(input + sb.toString());
        }else if(input.length() > 20){
            input = input.substring(0, 20);
            System.out.println(input);
        }
    }
}
