import java.io.BufferedReader;
import java.io.File;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;

public class t_05_line_numbers {
    public static void main(String[] args) {
        try (BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/inputLineNumbers.txt"))) {
            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/output.txt"));

            String line;
            int counter = 1;
            while ((line = reader.readLine()) != null) {
                writer.write(String.format("%d. %s%n", counter++ , line));
            }
            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
