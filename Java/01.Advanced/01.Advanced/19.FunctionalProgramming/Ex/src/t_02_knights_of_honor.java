import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.Consumer;

public class t_02_knights_of_honor {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Consumer<String> print = x -> System.out.println("Sir " + x);

        String[] tokens = reader.readLine().split("\\s+");

        for (String word: tokens) {
            print.accept(word);
        }
    }
}
