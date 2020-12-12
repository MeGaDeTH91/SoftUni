package t_01_listy_iterator;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        ListyIterator listyIterator = new ListyIterator(Arrays.stream(reader.readLine().split("\\s+")).skip(1).toArray(String[]::new));

        String line;
        String[] tokens;
        String command;
        while(!(line = reader.readLine()).equals("END")) {
            tokens = line.split("\\s+");
            command = tokens[0];

            switch (command) {
                case "Move":
                    System.out.println(listyIterator.move());
                    break;
                case "Print":
                    listyIterator.print();
                    break;
                case "HasNext":
                    System.out.println(listyIterator.hasNext());
                    break;
                default:
                    break;
            }
        }
    }
}
