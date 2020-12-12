import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.Consumer;

public class t_01_consumer_print {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Consumer<String> print = System.out::println;

        String[] tokens = reader.readLine().split("\\s+");

        for (String word: tokens) {
            print.accept(word);
        }
    }
}
