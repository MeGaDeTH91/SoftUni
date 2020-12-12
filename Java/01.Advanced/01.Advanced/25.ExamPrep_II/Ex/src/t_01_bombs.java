import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.stream.Collectors;

public class t_01_bombs {
    private static final BufferedReader reader;
    private static int daturaCount;
    private static int cherryCount;
    private static int smokeCount;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        daturaCount = 0;
        cherryCount = 0;
        smokeCount = 0;
    }

    public static void main(String[] args) throws IOException {

        Deque<Integer> effects = Arrays.stream(reader.readLine().split(", "))
                .map(Integer::parseInt)
                .collect(Collectors.toCollection(ArrayDeque::new));
        Deque<Integer> casings = new ArrayDeque<>();

        int[] casingInput = Arrays.stream(reader.readLine().split(", ")).mapToInt(Integer::parseInt).toArray();

        for (int casing: casingInput) {
            casings.push(casing);
        }

        int currentEffect;
        int currentCasing;
        while (!effects.isEmpty() && !casings.isEmpty() && !fullPouch()) {
            currentEffect = effects.poll();
            currentCasing = casings.pop();

            createBomb(currentEffect, currentCasing);
        }

        if (fullPouch()) {
            System.out.println("Bene! You have successfully filled the bomb pouch!");
        } else {
            System.out.println("You don't have enough materials to fill the bomb pouch.");
        }

        String result;
        if (effects.isEmpty()) {
            System.out.println("Bomb Effects: empty");
        } else {
            result = effects.stream().map(Object::toString)
                    .collect(Collectors.joining(", "));
            System.out.printf("Bomb Effects: %s%n", result);
        }

        if (casings.isEmpty()) {
            System.out.println("Bomb Casings: empty");
        } else {
            List<Integer> resultList = new ArrayList<>(casings);
            Collections.reverse(resultList);
            result = resultList.stream().map(Object::toString)
                    .collect(Collectors.joining(", "));
            System.out.printf("Bomb Casings: %s%n", result);
        }

        System.out.printf("Cherry Bombs: %d%n", cherryCount);
        System.out.printf("Datura Bombs: %d%n", daturaCount);
        System.out.printf("Smoke Decoy Bombs: %d%n", smokeCount);
    }

    private static void createBomb(int currentEffect, int currentCasing) {
        int currentSum = currentEffect + currentCasing;

        if (currentSum == 40) {
            daturaCount++;
        } else if (currentSum == 60) {
            cherryCount++;
        } else if (currentSum == 120) {
            smokeCount++;
        } else {
            createBomb(currentEffect, currentCasing - 5);
        }
    }

    private static boolean fullPouch() {
        return daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3;
    }
}
