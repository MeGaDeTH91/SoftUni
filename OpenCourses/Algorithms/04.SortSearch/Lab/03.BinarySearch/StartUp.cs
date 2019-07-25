namespace _03.BinarySearch
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

            int seekNum = int.Parse(Console.ReadLine());

            int elementIndex = BinarySearch.Find(numbers, seekNum);

            Console.WriteLine(elementIndex);
        }
    }
}
