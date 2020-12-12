import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.stream.Collectors;

public class t_01_scheduling {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int[] tasksInput = Arrays.stream(reader.readLine().split(", ")).mapToInt(Integer::parseInt).toArray();
        Deque<Integer> tasks = new ArrayDeque<>();


        for (int task: tasksInput) {
            tasks.push(task);
        }

        Deque<Integer> threads = Arrays.stream(reader.readLine().split(" "))
                .map(Integer::parseInt)
                .collect(Collectors.toCollection(ArrayDeque::new));

        int taskToKill = Integer.parseInt(reader.readLine());

        int currentTask;
        int currentThread;
        while (!tasks.isEmpty() && !threads.isEmpty()) {
            currentTask = tasks.pop();
            currentThread = threads.peek();

            if (currentTask == taskToKill) {
                System.out.printf("Thread with value %d killed task %d", currentThread, currentTask);
                System.out.println();
                break;
            }
            if (currentThread < currentTask) {
                tasks.push(currentTask);
            }
            threads.poll();
        }

        String result = threads.stream().map(Object::toString)
                .collect(Collectors.joining(" "));

        System.out.println(result);
    }
}
