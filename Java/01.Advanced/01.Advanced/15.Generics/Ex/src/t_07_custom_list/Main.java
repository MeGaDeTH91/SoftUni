package t_07_custom_list;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        MyList<String> list = new MyList<>();

        String line;
        String[] tokens;
        String action;
        String element;
        int firstIndex;
        int secondIndex;
        while(!(line = reader.readLine()).equals("END")) {
            tokens = line.split("\\s+");
            action = tokens[0];

            switch (action) {
                case "Add":
                    element = tokens[1];
                    list.add(element);
                    break;
                case "Remove":
                    firstIndex = Integer.parseInt(tokens[1]);
                    list.remove(firstIndex);
                    break;
                case "Contains":
                    element = tokens[1];
                    System.out.println(list.contains(element));
                    break;
                case "Swap":
                    firstIndex = Integer.parseInt(tokens[1]);
                    secondIndex = Integer.parseInt(tokens[2]);
                    list.swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    element = tokens[1];
                    System.out.println(list.countGreaterThan(element));
                    break;
                case "Max":
                    System.out.println(list.getMax());
                    break;
                case "Min":
                    System.out.println(list.getMin());
                    break;
                case "Print":
                    list.print();
                    break;
                default:
                    break;
            }
        }
    }
}
