import java.io.BufferedReader;
import java.io.File;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;

public class t_06_word_count {
    public static void main(String[] args) {
        try {
            String[] words = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/words.txt")).readLine().split("\\s+");
            BufferedReader reader = Files.newBufferedReader(Paths.get(System.getProperty("user.dir") + "../../Resources/text.txt"));
            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/results.txt"));

            Map<String, Integer> wordsCount = new HashMap<>();
            for (String word: words) {
                wordsCount.put(word, 0);
            }

            String line;
            String[] lineTokens;
            int wordCurrentCount;
            while ((line = reader.readLine()) != null) {
                lineTokens = line.split("\\s+");

                for (String currentWord: lineTokens) {
                    if (wordsCount.containsKey(currentWord)) {
                        wordCurrentCount = wordsCount.get(currentWord);
                        wordsCount.put(currentWord, wordCurrentCount + 1);
                    }
                }

            }
            for (String word: words) {
                writer.write(String.format("%s - %d%n", word, wordsCount.get(word)));
            }

            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
