import java.io.BufferedReader;
import java.nio.file.Files;
import java.nio.file.Paths;

public class t_02_sum_bytes {
    public static void main(String[] args) {
        try (BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/input.txt"))) {
            String line;
            int lineLength;
            long total = 0;
            while ((line = reader.readLine()) != null) {
                lineLength = line.length();

                for (int i = 0; i < lineLength; i++) {
                    total += (int) line.charAt(i);
                }
            }
            System.out.println(total);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
