import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.BiFunction;
import java.util.function.Function;
import java.util.stream.Collectors;

public class t_05_reverse_and_exclude {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int[] numbers = Arrays.stream(reader.readLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        int divisor = Integer.parseInt(reader.readLine());

        BiFunction<int[], Integer, List<Integer>> reverse = (arr, divideNum) -> {
            List<Integer> result = new ArrayList<>();

            int num;
            for (int i = arr.length - 1; i >= 0; i--) {
                num = arr[i];

                if (num % divideNum != 0) {
                    result.add(num);
                }
            }

            return result;
        };

        List<Integer> res = reverse.apply(numbers, divisor);

        String printRes = res.stream().map(String::valueOf).collect(Collectors.joining(" "));

        System.out.println(printRes);
    }
}
