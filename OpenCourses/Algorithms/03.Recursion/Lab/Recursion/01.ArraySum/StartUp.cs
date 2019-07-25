namespace _01.ArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numArray = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startIndex = 0;

            int sum = RecursiveSum(startIndex, numArray);

            Console.WriteLine(sum);
        }

        private static int RecursiveSum(int index, int[] numArray)
        {
            if(index == numArray.Length - 1)
            {
                return numArray[index];
            }
            return numArray[index] + RecursiveSum(index + 1, numArray);
        }
    }
}
