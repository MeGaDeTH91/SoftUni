import java.io.BufferedReader;
import java.io.File;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;

public class t_07_merge_two_files {
    public static void main(String[] args) {
        try {
            BufferedReader firstFile = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/inputOne.txt"));
            BufferedReader secondFile = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/inputTwo.txt"));
            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/outputThree.txt"));

            String line;
            while ((line = firstFile.readLine()) != null) {
                writer.write(String.format("%s%n", line));
            }

            while ((line = secondFile.readLine()) != null) {
                writer.write(String.format("%s%n", line));
            }

            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
