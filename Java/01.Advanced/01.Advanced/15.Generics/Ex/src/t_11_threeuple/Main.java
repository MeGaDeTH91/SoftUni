package t_11_threeuple;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Tuple<String, String, String> firstTuple;
        Tuple<String, Integer, Boolean> secondTuple;
        Tuple<String, Double, String> thirdTuple;

        String line = reader.readLine();
        String[] tokens = line.split("\\s+");
        firstTuple = new Tuple<>(tokens[0] + " " + tokens[1], tokens[2], tokens[3]);

        line = reader.readLine();
        tokens = line.split("\\s+");
        secondTuple = new Tuple<>(tokens[0], Integer.parseInt(tokens[1]), tokens[2].equals("drunk"));

        line = reader.readLine();
        tokens = line.split("\\s+");
        thirdTuple = new Tuple<>(tokens[0], Double.parseDouble(tokens[1]), tokens[2]);

        System.out.println(firstTuple.toString());
        System.out.println(secondTuple.toString());
        System.out.println(thirdTuple.toString());
    }
}
