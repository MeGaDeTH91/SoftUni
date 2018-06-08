namespace P01_EvenNumsThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        private const string threadFinishedMessage = "Thread finished work";

        public static void Main(string[] args)
        {
            int[] borders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = borders[0];
            int end = borders[1];

            Thread evens = new Thread(() => PrintEvenNumbers(start, end));

            evens.Start();
            evens.Join();

            Console.WriteLine(threadFinishedMessage);
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
