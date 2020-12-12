import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Map;
import java.util.TreeMap;

public class t_04_count_symbols {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<Character, Integer> symbols = new TreeMap<>();

        String text = reader.readLine();

        int textLength = text.length();
        char currentChar;
        int currentValue;
        for (int i = 0; i < textLength; i++) {
            currentChar = text.charAt(i);

            if (!symbols.containsKey(currentChar)) {
                symbols.put(currentChar, 0);
            }

            currentValue = symbols.get(currentChar);
            symbols.put(currentChar, ++currentValue);
        }

        for (Map.Entry<Character, Integer> pair: symbols.entrySet()) {
            System.out.printf("%c: %d time/s%n", pair.getKey(), pair.getValue());
        }
    }
}
