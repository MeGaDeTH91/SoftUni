import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.stream.Collectors;

public class t_04_applied_arithmetic {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Function<int[], int[]> add = arr -> {
            for (int i = 0; i < arr.length; i++) {
                arr[i] = arr[i] + 1;
            }

            return arr;
        };

        Function<int[], int[]> multiply = arr -> {
            for (int i = 0; i < arr.length; i++) {
                arr[i] = arr[i] * 2;
            }

            return arr;
        };

        Function<int[], int[]> subtract = arr -> {
            for (int i = 0; i < arr.length; i++) {
                arr[i] = arr[i] - 1;
            }

            return arr;
        };

        int[] numbers = Arrays.stream(reader.readLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        String command;
        String result;
        while (!(command = reader.readLine()).equals("end")) {
            switch (command) {
                case "add":
                    numbers = add.apply(numbers);
                    break;
                case "multiply":
                    numbers = multiply.apply(numbers);
                    break;
                case "subtract":
                    numbers = subtract.apply(numbers);
                    break;
                case "print":
                    result = Arrays.stream(numbers).mapToObj(String::valueOf).collect(Collectors.joining(" "));
                    System.out.println(result);
                    break;
            }
        }
    }
}
