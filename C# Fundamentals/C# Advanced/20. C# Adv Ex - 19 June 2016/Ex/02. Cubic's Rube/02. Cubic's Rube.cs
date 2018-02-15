using System;
namespace _02._Cubic_s_Rube
{
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            long cubeSize = long.Parse(Console.ReadLine());

            long unchangedCells = cubeSize * cubeSize * cubeSize;
            long sum = 0;

            string command;
            while ((command = Console.ReadLine()) != "Analyze")
            {
                long[] currInputNums = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();

                long currRow = currInputNums[0];
                long currCol = currInputNums[1];
                long currDept = currInputNums[2];

                long currParticles = currInputNums[3];

                if(IsCellValid(currRow, currCol, currDept, cubeSize) && currParticles != 0)
                {
                    sum += currParticles;
                    unchangedCells--;
                }
                
            }
            Console.WriteLine(sum);
            Console.WriteLine(unchangedCells);
        }

        private static bool IsCellValid(long currRow, long currCol, long currDept, long cubeSize)
        {
            return currRow >= 0 && currRow < cubeSize && currCol >= 0 && currCol < cubeSize && currDept >= 0 && currDept < cubeSize;
        }
    }
}
