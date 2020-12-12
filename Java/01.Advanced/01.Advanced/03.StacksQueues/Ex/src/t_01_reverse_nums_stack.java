import java.util.*;

public class t_01_reverse_nums_stack {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Deque<Integer> nums = new ArrayDeque<>();

        Integer[] tokens = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        for (Integer token: tokens) {
            nums.push(token);
        }

        while (nums.size() >= 1) {
            int current = nums.pop();

            System.out.printf("%d ", current);
        }
        System.out.println();
    }
}
