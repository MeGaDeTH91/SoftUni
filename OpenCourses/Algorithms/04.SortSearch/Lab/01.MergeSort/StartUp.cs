namespace _01.MergeSort
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            MergeSort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
