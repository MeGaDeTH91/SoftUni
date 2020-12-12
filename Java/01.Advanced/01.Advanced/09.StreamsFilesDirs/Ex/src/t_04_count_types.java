import java.io.BufferedReader;
import java.io.File;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class t_04_count_types {
    public static void main(String[] args) {
        Set<Character> vowels = new HashSet<>(Arrays.asList('a', 'e', 'i', 'o', 'u'));
        Set<Character> punctuationMarks = new HashSet<>(Arrays.asList('.', ',', '!', '?'));

        int vowelsCount = 0;
        int consonantsCount = 0;
        int punctuationMarksCount = 0;
        try (BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/input.txt"))) {
            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/output.txt"));

            String line;
            String[] lineTokens;
            char current;
            while ((line = reader.readLine()) != null) {
                lineTokens = line.split("\\s+");

                for (int i = 0; i < lineTokens.length; i++) {
                    for (int j = 0; j < lineTokens[i].length(); j++) {
                        current = lineTokens[i].charAt(j);

                        if (vowels.contains(current)){
                            vowelsCount++;
                        } else if (punctuationMarks.contains(current)) {
                            punctuationMarksCount++;
                        } else {
                            consonantsCount++;
                        }
                    }
                }
            }
            writer.write(String.format("Vowels: %d%n", vowelsCount));
            writer.write(String.format("Consonants: %d%n", consonantsCount));
            writer.write(String.format("Punctuation: %d%n", punctuationMarksCount));
            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
