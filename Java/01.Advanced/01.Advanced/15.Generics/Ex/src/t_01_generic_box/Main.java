package t_01_generic_box;

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

        Box<String> box = new Box<>();

        for (int i = 0; i < rows; i++) {
            box.setValue(reader.readLine());
            System.out.println(box.toString());
        }
    }
}
