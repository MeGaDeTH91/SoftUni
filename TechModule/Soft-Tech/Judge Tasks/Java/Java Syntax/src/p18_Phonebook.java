import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p18_Phonebook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> registry = new HashMap<>();

        String input = scanner.nextLine();
        while(!input.equals("END")){
            String[] arr = input.split("\\s+");
            if(arr.length == 3){
                String name = arr[1];
                String number = arr[2];

                registry.put(name, number);
            }
            if(arr.length == 2){
                String searchName = arr[1];
                if(registry.containsKey(searchName)){
                    for (Map.Entry<String, String> s : registry.entrySet()) {
                        if(s.getKey().equals(searchName)){
                            System.out.println(s.getKey() + " -> " + s.getValue());
                        }
                    }
                }
                else{
                    System.out.println("Contact " + searchName + " does not exist.");
                }
            }
            input = scanner.nextLine();
        }
    }
}
