import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class t_07_fix_emails {
    private static final BufferedReader reader;
    private static final Set<String> forbidden;
    private static final Map<String, String> emails;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        forbidden = new HashSet<>(Arrays.asList(".us", ".uk", ".com"));
        emails = new LinkedHashMap<>(10);
    }

    public static void main(String[] args) throws IOException {
        String name;
        String email;
        String domain;
        int lastDot;
        while (!(name = reader.readLine()).equals("stop")) {
            email = reader.readLine();

            lastDot = email.lastIndexOf('.');
            domain = email.substring(lastDot);

            if (!forbidden.contains(domain.toLowerCase())) {
                emails.put(name, email);
            }
        }

        for (Map.Entry<String, String> pair: emails.entrySet()) {
            System.out.printf("%s -> %s%n", pair.getKey(), pair.getValue());
        }
    }
}
