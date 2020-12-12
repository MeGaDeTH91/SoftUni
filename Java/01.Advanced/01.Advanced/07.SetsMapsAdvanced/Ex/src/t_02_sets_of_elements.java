import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.stream.Collectors;

public class t_02_sets_of_elements {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        String[] arrTokens = reader.readLine().split("\\s+");

        int firstArrLength = Integer.parseInt(arrTokens[0]);
        int secondArrLength = Integer.parseInt(arrTokens[1]);

        Set<Integer> firstNums = new LinkedHashSet<>();
        Set<Integer> secondNums = new LinkedHashSet<>();

        int currentNum;
        for (int i = 0; i < firstArrLength; i++) {
            currentNum = Integer.parseInt(reader.readLine());
            firstNums.add(currentNum);
        }

        for (int i = 0; i < secondArrLength; i++) {
            currentNum = Integer.parseInt(reader.readLine());

            secondNums.add(currentNum);
        }

        Set<Integer> mergeSet = new LinkedHashSet<>(firstNums);
        mergeSet.retainAll(secondNums);

        String result = mergeSet.stream()
                .map(Objects::toString)
                .collect(Collectors.joining(" "));

        System.out.println(result);
    }
}
