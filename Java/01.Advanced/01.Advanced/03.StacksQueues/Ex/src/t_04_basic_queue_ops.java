import java.util.*;

public class t_04_basic_queue_ops {
    public static void main(String[] args) {
        Deque<Integer> numQueue = new ArrayDeque<>();

        Scanner scanner = new Scanner(System.in);

        Integer[] detailsArr = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        int elementsToRemove = detailsArr[1];
        int elementToCheck = detailsArr[2];

        Integer[] numbers = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Collections.addAll(numQueue, numbers);

        for (int i = 0; i < elementsToRemove; i++) {
            numQueue.poll();
        }

        if (numQueue.isEmpty()) {
            System.out.println(0);
        } else {
            String result = numQueue.contains(elementToCheck) ? "true" : String.valueOf(Collections.min(numQueue));
            System.out.println(result);
        }
    }
}
