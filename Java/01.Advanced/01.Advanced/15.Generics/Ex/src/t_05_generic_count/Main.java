package t_05_generic_count;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int rows = Integer.parseInt(reader.readLine());
        List<Box<String>> boxes = new ArrayList<>();

        Box<String> box;

        for (int i = 0; i < rows; i++) {
            box = new Box<>(reader.readLine());
            boxes.add(box);
        }

        String element = reader.readLine();
        int count = getCount(boxes, element);

        System.out.println(count);
    }

    public static <E> int getCount (List<Box<String>> collection, String element) {
        int count = 0;

        for (Box<String> box: collection) {
            if (box.isGreater(element)) {
                count++;
            }
        }

        return count;
    }
}
