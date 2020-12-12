import java.util.*;

public class t_03_max_element {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int commandCount = Integer.parseInt(scanner.nextLine());

        Deque<Integer> numStack = new ArrayDeque<>();
        HashSet<Integer> hash = new HashSet<>();

        Integer[] nums;
        int currentCommand;
        int currentElement;

        for (int i = 0; i < commandCount; i++) {
            nums = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

            currentCommand = nums[0];

            switch (currentCommand) {
                case 1:
                    currentElement = nums[1];
                    numStack.push(currentElement);
                    break;
                case 2:
                    if (numStack.size() > 0) {
                        numStack.pop();
                    }
                    break;
                case 3:
                    System.out.println(Collections.max(numStack));
                    break;
            }
        }

    }
}
