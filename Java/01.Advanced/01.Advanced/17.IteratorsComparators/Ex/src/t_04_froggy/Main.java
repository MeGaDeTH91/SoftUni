package t_04_froggy;

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
        Integer[] numbers = Arrays.stream(reader.readLine().split("[\\s,]+")).map(Integer::parseInt).toArray(Integer[]::new);
        reader.readLine();

        Lake<Integer> lake = new Lake<>(numbers);

        StringBuilder sb = new StringBuilder(17);

        for (Integer num: lake) {
            sb.append(String.format("%d, ", num));
        }

        sb.delete(sb.length() - 2, sb.length());

        System.out.println(sb.toString());
    }
}
