import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class t_02_basic_stack_ops {
    public static void main(String[] args) {
        Deque<Integer> numStack = new ArrayDeque<>();

        Scanner scanner = new Scanner(System.in);

        Integer[] detailsArr = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        Integer[] numbers = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        int pushCount = detailsArr[0];
        int popCount = detailsArr[1];
        int targetElement = detailsArr[2];


        for (int i = 0; i < pushCount; i++) {
            int currentNum = numbers[i];
            numStack.push(currentNum);
        }

        while (popCount > 0 && numStack.size() > 0) {
            numStack.pop();
            popCount--;
        }

        if (numStack.isEmpty()) {
            System.out.println(0);
        } else {
            int minElement = numStack.stream().min((a, b) -> a -b).get();

            String result = numStack.contains(targetElement) ? "true" : Integer.toString(minElement) ;

            System.out.println(result);
        }



    }
}
