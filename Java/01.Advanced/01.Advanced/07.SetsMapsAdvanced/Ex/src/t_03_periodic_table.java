import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.stream.Collectors;

public class t_03_periodic_table {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int compoundCount = Integer.parseInt(reader.readLine());

        Set<String> compounds = new TreeSet<>();

        List<String> currentCompounds;
        for (int i = 0; i < compoundCount; i++) {
            currentCompounds = Arrays.stream(reader.readLine().split("\\s+")).collect(Collectors.toList());

            compounds.addAll(currentCompounds);
        }

        System.out.println(String.join(" ", compounds));
    }
}
