using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputComm = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int pushNum = inputComm[0];
            int popNum = inputComm[1];
            int seekNum = inputComm[2];

            int[] inputArr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(inputArr);

            for (int i = 0; i < popNum; i++)
            {
                
                numStack.Pop();
            }

            if (numStack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int min = numStack.Min();
            bool exists = numStack.Contains(seekNum);
            if(exists)
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
