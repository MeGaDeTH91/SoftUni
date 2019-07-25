namespace _04.GenerateVectors
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int vecLength = int.Parse(Console.ReadLine());

            int[] vector = new int[vecLength];

            int startIndex = 0;
            GenerateVector(vector, startIndex);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVector(vector, index + 1);
            }
        }
    }
}
