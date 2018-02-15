using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();
            int maxElement = 0;

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int commandType = command[0];
                

                switch (commandType)
                {
                    case 1:
                        sequence.Push(command[1]);
                        if(command[1] > maxElement)
                        {
                            maxElement = command[1];
                        }
                        break;
                    case 2:
                        int popElement = sequence.Pop();
                        if(popElement == maxElement)
                        {
                            maxElement = sequence.Max();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxElement);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
