package t_04_traffic_lights;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        List<String> lights = new ArrayList<>(List.of(reader.readLine().split("\\s+")));

        int count = Integer.parseInt(reader.readLine());

        final String RED = "RED";
        final String GREEN = "GREEN";
        final String YELLOW = "YELLOW";

        for (int i = 0; i < count; i++) {
            for (int j = 0; j < lights.size(); j++) {
                String currLight = lights.get(j);

                switch (currLight) {
                    case RED:
                        lights.set(j, GREEN);
                        break;
                    case GREEN:
                        lights.set(j, YELLOW);
                        break;
                    case YELLOW:
                        lights.set(j, RED);
                        break;
                    default:
                        break;
                }
            }

            System.out.println(String.join(" ", lights));
        }
    }
}
