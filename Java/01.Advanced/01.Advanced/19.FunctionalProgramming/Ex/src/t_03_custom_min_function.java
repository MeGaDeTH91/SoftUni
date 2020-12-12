import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.function.Function;

public class t_03_custom_min_function {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Integer[] numbers = Arrays.stream(reader.readLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Function<Integer[], Integer> findMin = arr -> {
            int min = Integer.MAX_VALUE;

            for (int num: arr) {
                if (num < min) {
                    min = num;
                }
            }
            return min;
        };

        System.out.println(findMin.apply(numbers));
    }
}
