import java.util.Random;
import java.util.Scanner;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p21_AdvMessage {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        String[] phrases = {"Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can’t live without this product."};
        String[] events = {"Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};
        String[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
        String[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
        Random randomGenerate = new Random();
        String output = "";

        for (int i = 0; i < n; i++) {
            int rnd = randomGenerate.nextInt(phrases.length - 1) + 1;
            output += " " + phrases[rnd];
            rnd = randomGenerate.nextInt(events.length - 1) + 1;
            output += " " + events[rnd];
            rnd = randomGenerate.nextInt(authors.length - 1) + 1;
            output += " " + authors[rnd];
            rnd = randomGenerate.nextInt(cities.length - 1) + 1;
            output += " - " + cities[rnd];
            System.out.println(output);
            output = "";
        }
    }
}
