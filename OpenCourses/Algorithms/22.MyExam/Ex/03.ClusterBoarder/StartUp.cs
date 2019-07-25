namespace _03.ClusterBoarder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static long[] shipRecord;
        private static long[] allShips;
        private static long[] pairedShips;

        public static void Main()
        {
            allShips = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            pairedShips = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            shipRecord = new long[allShips.Length + 1];

            FillRecord();

            long optimalTime = shipRecord[shipRecord.Length - 1];

            List<string> sb = new List<string>();

            int index = allShips.Length;

            while (index > 0)
            {
                if (shipRecord[index - 1] + allShips[index - 1] == shipRecord[index])
                {
                    sb.Add($"Single {index}");
                    index--;
                }
                else
                {
                    sb.Add($"Pair of {index - 1} and {index}");
                    index -= 2;
                }
            }

            sb.Reverse();

            Console.WriteLine($"Optimal Time: {optimalTime}");

            Console.WriteLine(string.Join(Environment.NewLine, sb));
        }

        private static void FillRecord()
        {
            shipRecord[0] = 0;
            shipRecord[1] = allShips[0];

            for (int i = 2; i <= allShips.Length; i++)
            {
                shipRecord[i] = Math.Min(shipRecord[i - 1] + allShips[i - 1], shipRecord[i - 2] + pairedShips[i - 2]);
            }
        }
    }
}
