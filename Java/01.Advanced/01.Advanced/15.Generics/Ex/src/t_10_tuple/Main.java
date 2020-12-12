package t_10_tuple;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Tuple<String, String> firstTuple;
        Tuple<String, Integer> secondTuple;
        Tuple<Integer, Double> thirdTuple;

        String line = reader.readLine();
        String[] tokens = line.split("\\s+");
        firstTuple = new Tuple<>(tokens[0] + " " + tokens[1], tokens[2]);

        line = reader.readLine();
        tokens = line.split("\\s+");
        secondTuple = new Tuple<>(tokens[0], Integer.parseInt(tokens[1]));

        line = reader.readLine();
        tokens = line.split("\\s+");
        thirdTuple = new Tuple<>(Integer.parseInt(tokens[0]), Double.parseDouble(tokens[1]));

        System.out.println(firstTuple.toString());
        System.out.println(secondTuple.toString());
        System.out.println(thirdTuple.toString());
    }
}
