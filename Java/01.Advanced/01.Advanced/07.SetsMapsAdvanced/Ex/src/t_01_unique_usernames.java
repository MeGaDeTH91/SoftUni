import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class t_01_unique_usernames {
    private static BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int lineCount = Integer.parseInt(reader.readLine());

        List<String> names = new ArrayList<>();
        Set<String> uniqueNames = new HashSet<>();

        String name;
        for (int i = 0; i < lineCount; i++) {
            name = reader.readLine();

            if (!uniqueNames.contains(name)) {
                names.add(name);
                uniqueNames.add(name);
            }
        }

        System.out.println(String.join("\n", names));
    }
}
