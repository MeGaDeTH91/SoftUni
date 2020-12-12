package t_02_integer_box;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int rows = Integer.parseInt(reader.readLine());

        Box<Integer> box = new Box<>();

        for (int i = 0; i < rows; i++) {
            box.setValue(Integer.parseInt(reader.readLine()));
            System.out.println(box.toString());
        }
    }
}
