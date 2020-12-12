import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

public class t_07_find_smallest_element {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        List<Integer> numbers = Arrays.stream(reader.readLine().split("\\s+")).map(Integer::valueOf).collect(Collectors.toList());

        System.out.println(getSmallest.apply(numbers));
    }

    private static final Function<List<Integer>, Integer> getSmallest = list -> {
        int min = Integer.MAX_VALUE;

        int foundIndex = 0;

        int listSize = list.size();
        int currNum;
        for (int i = 0; i < listSize; i++) {
            currNum = list.get(i);

            if (currNum <= min) {
                min = currNum;
                foundIndex = i;
            }
        }

        return foundIndex;
    };
}
