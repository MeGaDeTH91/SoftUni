import java.io.BufferedReader;
import java.io.File;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;

public class t_03_all_capitals {
    public static void main(String[] args) {
        try (BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/input.txt"))) {
            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/output.txt"));

            String line;
            while ((line = reader.readLine()) != null) {
                writer.write(String.format("%s%n", line.toUpperCase()));
            }
            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
