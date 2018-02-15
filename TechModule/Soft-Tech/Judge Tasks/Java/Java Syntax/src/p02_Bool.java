import java.util.Scanner;

/**
 * Created by Marto on 4.8.2017 г..
 */
public class p02_Bool {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine().toLowerCase();
        if(input.equals("true")){
            System.out.println("Yes");
        }else{
            System.out.println("No");
        }
    }
}
