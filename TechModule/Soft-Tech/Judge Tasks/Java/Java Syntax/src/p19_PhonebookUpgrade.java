import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p19_PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> registry = new HashMap<>();

        String input = scanner.nextLine();
        while(!input.equals("END")){
            String[] arr = input.split("\\s+");
            if(input.equals("ListAll")){
                TreeMap<String, String> sorted = new TreeMap<>(registry);
                for (Map.Entry<String, String> entry : sorted.entrySet()) {
                    System.out.println(entry.getKey() + " -> " + entry.getValue());
                }
            }
            else if(arr.length == 3){
                String name = arr[1];
                String number = arr[2];
                registry.put(name, number);
            }
            else if(arr.length == 2){
                String searchName = arr[1];
                if(registry.containsKey(searchName)){
                    for (Map.Entry<String, String> s : registry.entrySet()) {
                        if(s.getKey().equals(searchName)){
                            System.out.println(s.getKey() + " -> " + s.getValue());
                        }
                    }
                } else{
                    System.out.println("Contact " + searchName + " does not exist.");
                }
            }

            input = scanner.nextLine();
        }
    }
}
