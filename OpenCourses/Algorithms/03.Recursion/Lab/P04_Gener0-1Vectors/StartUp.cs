using System;

namespace P04_Gener0_1Vectors
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] numbers = new int[number];

            GenerateVector(numbers, 0);
        }

        private static void GenerateVector(int[] numbers, int index)
        {
            if(index >= numbers.Length)
            {
                Console.WriteLine(string.Join("", numbers));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    numbers[index] = i;

                    GenerateVector(numbers, index + 1);

                }
            }
        }
    }
}
