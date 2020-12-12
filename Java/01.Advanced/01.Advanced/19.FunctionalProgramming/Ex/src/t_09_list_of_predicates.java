import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.BiPredicate;
import java.util.stream.Collectors;

public class t_09_list_of_predicates {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int limit = Integer.parseInt(reader.readLine());
        Integer[] divisorsArr = Arrays.stream(reader.readLine().split("\\s+")).map(Integer::valueOf).toArray(Integer[]::new);

        List<Integer> result = new ArrayList<>();

        for (int i = 1; i <= limit; i++) {
            if (checkDivisors.test(divisorsArr, i)) {
                result.add(i);
            }
        }

        String print = result.stream().map(String::valueOf).collect(Collectors.joining(" "));

        System.out.println(print);
    }

    private static final BiPredicate<Integer[], Integer> checkDivisors = (divisors, num) -> {
        boolean isDivisible = true;

        for (int currNum: divisors) {
            if (num % currNum != 0) {
                isDivisible = false;
                break;
            }
        }

        return isDivisible;
    };
}
