import java.io.BufferedReader;
import java.nio.file.Files;
import java.nio.file.Paths;

public class t_01_sum_lines {
    public static void main(String[] args) {
        try (BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/input.txt"))) {
            String line;
            int lineLength;
            long total;
            while ((line = reader.readLine()) != null) {
                total = 0;
                lineLength = line.length();

                for (int i = 0; i < lineLength; i++) {
                    total += (int) line.charAt(i);
                }
                System.out.println(total);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
