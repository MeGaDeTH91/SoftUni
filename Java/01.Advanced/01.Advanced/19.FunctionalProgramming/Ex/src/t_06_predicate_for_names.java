import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.BiPredicate;

public class t_06_predicate_for_names {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int targetLength = Integer.parseInt(reader.readLine());
        String[] names = reader.readLine().split("\\s+");

        for (String name: names) {
            if (checkName.test(name, targetLength)) {
                System.out.println(name);
            }
        }
    }

    private static final BiPredicate<String, Integer> checkName = (name, target) -> name.length() <= target;
}
