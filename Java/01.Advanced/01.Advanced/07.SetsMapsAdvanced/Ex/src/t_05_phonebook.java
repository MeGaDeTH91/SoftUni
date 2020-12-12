import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class t_05_phonebook {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, String> phonebook = new HashMap<>();

        String command;
        String[] currTokens;
        while (!(command = reader.readLine()).equals("search")) {
            currTokens = command.split("-");

            phonebook.put(currTokens[0], currTokens[1]);
        }

        while (!(command = reader.readLine()).equals("stop")) {
            if (phonebook.containsKey(command)) {
                System.out.printf("%s -> %s%n", command, phonebook.get(command));
            } else {
                System.out.printf("Contact %s does not exist.%n", command);
            }
        }
    }
}
