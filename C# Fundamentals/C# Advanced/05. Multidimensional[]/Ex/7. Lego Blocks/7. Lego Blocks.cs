using System;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowNum = int.Parse(Console.ReadLine());

            int[][] leftJaggArr = new int[rowNum][];
            int[][] rightJaggArr = new int[rowNum][];

            int[][] resultJaggArr = new int[rowNum][];

            for (int i = 0; i < rowNum; i++)
            {
                int[] currRow = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                leftJaggArr[i] = new int[currRow.Length];
                for (int index = 0; index < currRow.Length; index++)
                {
                    leftJaggArr[i][index] = currRow[index];
                }
            }

            for (int i = 0; i < rowNum; i++)
            {
                int[] currRow = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                rightJaggArr[i] = new int[currRow.Length];
                for (int index = 0; index < currRow.Length; index++)
                {
                    rightJaggArr[i][index] = currRow[index];
                }
                rightJaggArr[i] = rightJaggArr[i].Reverse().ToArray();
            }

            for (int i = 0; i < rowNum; i++)
            {
                int arrCount = leftJaggArr[i].Length + rightJaggArr[i].Length;

                resultJaggArr[i] = new int[arrCount];
                for (int currRow = 0; currRow < leftJaggArr[i].Length; currRow++)
                {
                    resultJaggArr[i][currRow] = leftJaggArr[i][currRow];
                }

                int startIndex = arrCount - rightJaggArr[i].Length;
                for (int currRow = startIndex; currRow < resultJaggArr[i].Length; currRow++)
                {
                    resultJaggArr[i][currRow] = rightJaggArr[i][currRow- startIndex];
                }

            }

            bool isSquare = true;

            for (int index = 0; index < resultJaggArr.GetLength(0) - 1; index++)
            {
                if(resultJaggArr[index].Length != resultJaggArr[index + 1].Length)
                {
                    isSquare = false;
                    break;
                }
                else
                {
                    isSquare = true;
                }
            }

            if(isSquare)
            {
                foreach (var result in resultJaggArr)
                {
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
            }
            else
            {
                int sum = 0;
                foreach (var arr in resultJaggArr)
                {
                    sum += arr.Length;
                }
                Console.WriteLine($"The total number of cells is: {sum}");
            }
        }
    }
}
