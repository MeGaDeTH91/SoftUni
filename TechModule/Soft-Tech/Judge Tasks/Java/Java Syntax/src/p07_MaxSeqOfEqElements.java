import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class p07_MaxSeqOfEqElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] input = Arrays.stream(scanner.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        ArrayList<Integer> maxSequenceOfEqualElements = FindMaxSequence(input);

        //for (int i = 0; i < maxSequenceOfEqualElements.length; i++)
           // System.out.print(maxSequenceOfEqualElements[i] + " ");
        StringBuilder sb = new StringBuilder();
        String delim = "";
        for (int i : maxSequenceOfEqualElements) {
            sb.append(delim).append(i);
            delim = " ";
        }

        System.out.println(sb.toString());
    }
    private static ArrayList<Integer> FindMaxSequence(int[] arr)
    {
        ArrayList<Integer> longestSequenceOfEq = new ArrayList<Integer>();
        ArrayList<Integer> currentSequenceOfEq = new ArrayList<Integer>();

        currentSequenceOfEq.add(arr[0]);
        for (int i = 1; i < arr.length; i++)
        {
            if(arr[i] == arr[i - 1])
            {
                currentSequenceOfEq.add(arr[i]);
                if(i == arr.length - 1 && currentSequenceOfEq.size() > longestSequenceOfEq.size())
                {
                    longestSequenceOfEq = new ArrayList<Integer>(currentSequenceOfEq);
                    currentSequenceOfEq = new ArrayList<Integer>();
                    currentSequenceOfEq.add(arr[i]);
                }
            }
            else
            {
                if(currentSequenceOfEq.size() > longestSequenceOfEq.size())
                {
                    longestSequenceOfEq = new ArrayList<Integer>(currentSequenceOfEq);

                }
                currentSequenceOfEq = new ArrayList<Integer>();
                currentSequenceOfEq.add(arr[i]);

            }
        }
        return longestSequenceOfEq;
    }
}
