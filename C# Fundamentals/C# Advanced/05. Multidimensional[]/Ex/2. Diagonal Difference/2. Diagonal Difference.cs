using System;
using System.Linq;

namespace _2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] sqMatrix= new int[size, size];

            for (int rows = 0; rows < size; rows++)
            {
                int[] input = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                for (int cols = 0; cols < size; cols++)
                {
                    sqMatrix[rows, cols] = input[cols];
                }
            }

            int result = 0;
            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int index = 0; index < size; index++)
            {
                firstDiagonal += sqMatrix[index, index];                
            }

            int row = 0;
            for (int index = size- 1; index >= 0; index--)
            {
                secondDiagonal += sqMatrix[row, index];
                row++;
            }

            result = Math.Abs(firstDiagonal - secondDiagonal);

            Console.WriteLine(result);
        }
    }
}
