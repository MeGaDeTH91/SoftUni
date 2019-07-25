namespace _01.Zerg
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        private static BigInteger[][] matrix;
        private static bool[][] enemies;
        private static int rowCount;
        private static int colCount;
        private static int rowBase;
        private static int colBase;

        public static void Main()
        {
            ReadInput();

            CheckMatrix();

            PrintResult();
        }

        private static void CheckMatrix()
        {
            for (int row = 0; row <= rowBase; row++)
            {
                for (int col = 0; col <= colBase; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        matrix[row][col] = 1;
                        continue;
                    }

                    if (!enemies[row][col])
                    {
                        BigInteger count = 0;

                        if (row > 0)
                        {
                            count += matrix[row - 1][col];
                        }
                        if (col > 0)
                        {
                            count += matrix[row][col - 1];
                        }

                        matrix[row][col] = count;
                    }
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(matrix[rowBase][colBase]);
        }

        private static void ReadInput()
        {
            int[] dimensions = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            rowCount = dimensions[0];
            colCount = dimensions[1];

            matrix = new BigInteger[rowCount][];
            enemies = new bool[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                matrix[row] = new BigInteger[colCount];
                enemies[row] = new bool[colCount];
            }

            int[] baseDetails = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowBase = baseDetails[0];
            colBase = baseDetails[1];

            int enemyCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enemyCount; i++)
            {
                int[] enemyTokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int rowEnemy = enemyTokens[0];
                int colEnemy = enemyTokens[1];

                enemies[rowEnemy][colEnemy] = true;
            }
        }
    }
}
