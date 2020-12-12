import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.stream.Collectors;

public class t_01_flower_wreaths {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int[] liliesInput = Arrays.stream(reader.readLine().split(", ")).mapToInt(Integer::parseInt).toArray();
        Deque<Integer> lilies = new ArrayDeque<>();
        Deque<Integer> roses = Arrays.stream(reader.readLine().split(", ")).map(Integer::parseInt).collect(Collectors.toCollection(ArrayDeque::new));

        for (int lily: liliesInput) {
            lilies.push(lily);
        }

        int wreathsCount = 0;
        int storedFlowers = 0;

        int currentLily;
        int currentRose;
        int currentSum;
        while (!lilies.isEmpty() && !roses.isEmpty()) {
            currentLily = lilies.pop();
            currentRose = roses.poll().intValue();
            currentSum = currentLily + currentRose;

            if (currentSum == 15) {
                wreathsCount++;
            } else if (currentSum > 15) {
                while (currentSum > 15) {
                    currentLily -= 2;
                    currentSum = currentLily + currentRose;
                }

                if (currentSum == 15) {
                    wreathsCount++;
                } else {
                    storedFlowers += currentSum;
                }
            } else {
                storedFlowers += currentSum;
            }
        }

        wreathsCount += storedFlowers / 15;

        if (wreathsCount >= 5) {
            System.out.printf("You made it, you are going to the competition with %d wreaths!%n", wreathsCount);
        } else {
            System.out.printf("You didn't make it, you need %d wreaths more!%n", 5 - wreathsCount);
        }
    }
}
