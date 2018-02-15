using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimension = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int rowCount = matrixDimension[0];
            int colCount = matrixDimension[1];

            List<List<int>> matrix = new List<List<int>>();

            int startValue = 1;
            for (int rows = 0; rows < rowCount; rows++)
            {
                List<int> rowList = new List<int>();
                for (int cols = 0; cols < colCount; cols++)
                {
                    rowList.Add(startValue);
                    startValue++;
                }
                matrix.Add(rowList);
            }

            string command;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] nukeParams = command
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                int impactRow = nukeParams[0];
                int impactCol = nukeParams[1];
                int radius = nukeParams[2];

                CrossFire(matrix, impactRow, impactCol, radius);
                ArrangeElements(matrix);
                
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join(" ", m));
            }
        }

        private static void ArrangeElements(List<List<int>> matrix)
        {
            for (int rows = 0; rows < matrix.Count; rows++)
            {
                matrix[rows].RemoveAll(x => x == 0);
                if(matrix[rows].Count == 0)
                {
                    matrix.RemoveAt(rows);
                    rows--;
                }
            }
        }

        private static void CrossFire(List<List<int>> matrix, int impactRow, int impactCol, int radius)
        {
            for (int rows = 0; rows < matrix.Count; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Count; cols++)
                {
                    if ((rows == impactRow && Math.Abs(cols - impactCol) <= radius) ||
                            (cols == impactCol && Math.Abs(rows - impactRow) <= radius))
                    {
                        matrix[rows][cols] = 0;
                    }
                }
            }
        }
    }
}
