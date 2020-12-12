import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.Comparator;
import java.util.stream.Collectors;

public class t_08_custom_comparator {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Integer[] nums = Arrays.stream(reader.readLine().split("\\s+")).map(Integer::valueOf).toArray(Integer[]::new);

        Arrays.sort(nums, new CustomComparator());

        String result = Arrays.stream(nums).map(String::valueOf).collect(Collectors.joining(" "));

        System.out.println(result);
    }

    private static class CustomComparator implements Comparator<Integer> {

        @Override
        public int compare(Integer num1, Integer num2) {
            if (num1 % 2 == 0 && num2 % 2 == 0) {
                return num1.compareTo(num2);
            }

            if (num1 % 2 == 0) {
                return -1;
            } else if (num2 % 2 == 0){
                return 1;
            } else {
                return num1.compareTo(num2);
            }
        }
    }
}
