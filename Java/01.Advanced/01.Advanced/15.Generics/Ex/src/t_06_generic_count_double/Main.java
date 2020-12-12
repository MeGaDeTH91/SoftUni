package t_06_generic_count_double;

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
        List<Box<Double>> boxes = new ArrayList<>();

        Box<Double> box;

        for (int i = 0; i < rows; i++) {
            box = new Box<>(Double.parseDouble(reader.readLine()));
            boxes.add(box);
        }

        double element = Double.parseDouble(reader.readLine());
        int count = getCount(boxes, element);

        System.out.println(count);
    }

    public static <E> int getCount (List<Box<Double>> collection, double element) {
        int count = 0;

        for (Box<Double> box: collection) {
            if (box.isGreater(element)) {
                count++;
            }
        }

        return count;
    }
}
