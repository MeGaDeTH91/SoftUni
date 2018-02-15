import java.util.Arrays;
import java.util.Scanner;

/**
 * Created by Marto on 4.8.2017 г..
 */
public class p06_CompareCharArr {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String frstInput = scanner.nextLine();
        String scndInput = scanner.nextLine();

        char[] first = frstInput.replaceAll(" ", "").toCharArray();
        char[] second = scndInput.replaceAll(" ", "").toCharArray();

        if(first.length < second.length){
            String frstStr = new String(first);
            String scndStr = new String(second);
            System.out.println(frstStr);
            System.out.println(scndStr);
        } else if(first.length > second.length){
            String frstStr = new String(first);
            String scndStr = new String(second);
            System.out.println(scndStr);
            System.out.println(frstStr);
        } else{
            int border = first.length;
            int count = 0;
            for (int i = 0; i < border; i++) {
                char currA = first[i];
                char currB = second[i];
                if(currA == currB){
                    count++;
                } else if(currA < currB){
                    System.out.println(first);
                    System.out.println(second);
                    return;
                } else if(currA > currB){
                    System.out.println(second);
                    System.out.println(first);
                    return;
                }
            }
            if(count == border){
                System.out.println(first);
                System.out.println(second);
            }
        }
    }
}