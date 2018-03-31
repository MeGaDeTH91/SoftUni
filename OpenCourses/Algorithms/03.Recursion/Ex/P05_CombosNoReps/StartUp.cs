using System;

public class StartUp
{
    static void Main(string[] args)
    {
        int elementSet = int.Parse(Console.ReadLine());
        int elementSelected = int.Parse(Console.ReadLine());

        int[] arr = new int[elementSelected];

        ShowCombinations(arr, elementSet, 0, 1);
    }

    private static void ShowCombinations(int[] arr, int elementSet, int index, int element)
    {
        if (index >= arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
        else
        {
            for (int i = element; i <= elementSet; i++)
            {
                arr[index] = i;
                ShowCombinations(arr, elementSet, index + 1, i + 1);
            }
        }
    }
}
