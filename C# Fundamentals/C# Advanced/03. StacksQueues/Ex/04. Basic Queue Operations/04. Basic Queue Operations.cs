using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int popNum = command[1];
            int seekNum = command[2];

            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numQueue = new Queue<int>(numbers);

            for (int i = 0; i < popNum; i++)
            {
                numQueue.Dequeue();
            }
            if (numQueue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int min = numQueue.Min();
            bool exists = numQueue.Contains(seekNum);

            if (exists)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(min);
            }
        }
    }
}
