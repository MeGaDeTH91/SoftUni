import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class t_06_miner_task {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, Integer> resources = new HashMap<>();

        String resource;
        int quantity;
        int storedQuantity;
        while (!(resource = reader.readLine()).equals("stop")) {
            quantity = Integer.parseInt(reader.readLine());

            if (!resources.containsKey(resource)) {
                resources.put(resource, 0);
            }

            storedQuantity = resources.get(resource);
            resources.put(resource, storedQuantity + quantity);
        }

        for (Map.Entry<String, Integer> pair: resources.entrySet()) {
            System.out.printf("%s -> %d%n", pair.getKey(), pair.getValue());
        }
    }
}
