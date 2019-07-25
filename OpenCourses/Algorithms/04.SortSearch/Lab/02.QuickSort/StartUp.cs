namespace _02.QuickSort
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

            QuickSort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
