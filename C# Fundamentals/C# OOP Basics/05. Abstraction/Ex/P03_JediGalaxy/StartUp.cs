using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowCount = dimensions[0];
            int colCount = dimensions[1];
            
            int[][] galaxy = new int[rowCount][];

            int valueToAdd = 0;
            for (int row = 0; row < rowCount; row++)
            {
                galaxy[row] = new int[colCount];
                for (int col = 0; col < colCount; col++)
                {
                    galaxy[row][col] = valueToAdd++;
                }
            }

            long sum = 0L;

            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoPosition = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int[] evilPosition = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilPosition[0];
                int evilCol = evilPosition[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if(IsCellValid(evilRow, evilCol, rowCount, colCount))
                    {
                        galaxy[evilRow][evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int ivoRow = ivoPosition[0];
                int ivoCol = ivoPosition[1];

                while (ivoRow >= 0 && ivoCol < colCount)
                {
                    if (IsCellValid(ivoRow, ivoCol, rowCount, colCount))
                    {
                        sum += galaxy[ivoRow][ivoCol];
                    }
                    ivoCol++;
                    ivoRow--;
                }
            }
            Console.WriteLine(sum);
        }

        public static bool IsCellValid(int row, int col, int rowCount, int colCount)
        {
            return row >= 0 && row < rowCount && col >= 0 && col < colCount;
        }
    }
}
