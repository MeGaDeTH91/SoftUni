import java.util.Arrays;
import java.util.Scanner;

/**
 * Created by Marto on 6.8.2017 г..
 */
public class p09_MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] numArray = Arrays.stream(scanner.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        int mostFrequent = 0;
        int repetitions = 0;
        for (int i = 0; i < numArray.length; i++)
        {
            int currNum = numArray[i];
            int counter = 0;
            for (int j = 0; j < numArray.length; j++)
            {
                if (currNum == numArray[j])
                {
                    counter++;

                }
            }
            if(counter > repetitions)
            {
                mostFrequent = currNum;
                repetitions = counter;
            }
        }
        System.out.println(mostFrequent);
    }
}
