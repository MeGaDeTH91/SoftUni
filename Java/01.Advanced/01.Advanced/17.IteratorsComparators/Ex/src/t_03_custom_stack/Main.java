package t_03_custom_stack;

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
        CustomStack<Integer> stack = new CustomStack<>();

        String line;
        String[] tokens;
        String command;
        while(!(line = reader.readLine()).equals("END")) {
            tokens = line.split("[\\s,]+");

            command = tokens[0];

            switch (command) {
                case "Push":
                    stack.push(Arrays.stream(tokens).skip(1).map(Integer::parseInt).toArray(Integer[]::new));
                    break;
                case "Pop":
                    stack.pop();
                    break;
                default:
                    break;
            }
        }

        for (int i = 0; i < 2; i++) {
            for (int j = stack.size() - 1; j >= 0; j--) {
                System.out.println(stack.getElementAt(j));
            }
        }
    }
}
