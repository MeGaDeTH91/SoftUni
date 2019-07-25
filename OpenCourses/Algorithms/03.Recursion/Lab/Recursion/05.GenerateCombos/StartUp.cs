namespace _05.GenerateCombos
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int vectorLength = int.Parse(Console.ReadLine());
            int[] vector = new int[vectorLength];

            int startIndex = 0;

            GenCombos(numArray, vector, startIndex, startIndex);
        }

        private static void GenCombos(int[] numArray, int[] vector, int index, int border)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            for (int i = border; i < numArray.Length; i++)
            {
                vector[index] = numArray[i];
                GenCombos(numArray, vector, index + 1, i + 1);
            }
        }
    }
}
