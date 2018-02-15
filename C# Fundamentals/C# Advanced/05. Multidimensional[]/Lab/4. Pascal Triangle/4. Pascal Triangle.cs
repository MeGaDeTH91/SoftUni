using System;

namespace _4._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long triangleHeight = long.Parse(Console.ReadLine());

            long[][] triangle = new long[triangleHeight][];

            for (long row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;

                if(row >= 2)
                {
                    for (long col = 1; col < row; col++)
                    {
                        triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                    }
                }
            }

            foreach (var tr in triangle)
            {
                Console.WriteLine(string.Join(" ", tr));
            }
        }
    }
}
