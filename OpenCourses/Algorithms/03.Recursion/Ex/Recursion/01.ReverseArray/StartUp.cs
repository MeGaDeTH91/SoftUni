namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] resultArr;

        public static void Main()
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            resultArr = new int[array.Length];

            ReverseIt(0, array.Length - 1, array);
        }

        private static void ReverseIt(int resultIndex, int sourceIndex, int[] array)
        {
            if(resultIndex == array.Length)
            {
                Console.WriteLine(string.Join(" ", resultArr));
            }
            else
            {
                resultArr[resultIndex] = array[sourceIndex];
                ReverseIt(resultIndex + 1, sourceIndex - 1, array);
            }
        }
    }
}
