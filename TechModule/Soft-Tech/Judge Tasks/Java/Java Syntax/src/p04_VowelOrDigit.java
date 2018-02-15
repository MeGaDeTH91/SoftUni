import java.util.Scanner;

/**
 * Created by Marto on 4.8.2017 г..
 */
public class p04_VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine().toLowerCase();

        char s = input.charAt(0);
        if(input.equals("a") || input.equals("o") || input.equals("e") || input.equals("i") ||
                input.equals("y") || input.equals("u")){
            System.out.println("vowel");
        }else if(Character.isDigit(s)){
            System.out.println("digit");
        }else {
            System.out.println("other");
        }
    }
}
