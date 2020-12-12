package t_04_generic_swap_integers;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int rows = Integer.parseInt(reader.readLine());

        List<Integer> elements = new ArrayList<>(8);

        for (int i = 0; i < rows; i++) {
            elements.add(Integer.parseInt(reader.readLine()));
        }

        int[] indexes = Arrays.stream(reader.readLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        swap (elements, indexes[0], indexes[1]);
    }

    public static <E> void swap (List<E> collection, int firstIndex, int secondIndex) {
        E el = collection.get(firstIndex);
        collection.set(firstIndex, collection.get(secondIndex));
        collection.set(secondIndex, el);

        for (E element: collection) {
            System.out.printf("%s: %s%n", element.getClass().getName(), element.toString());
        }
    }
}
