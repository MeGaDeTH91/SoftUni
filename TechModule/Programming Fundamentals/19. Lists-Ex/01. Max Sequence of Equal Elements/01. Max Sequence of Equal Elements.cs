using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var maxSequenceOfEqualElements = FindMaxSequence(input);
            Console.WriteLine(string.Join(" ", maxSequenceOfEqualElements));
        }

         static int[] FindMaxSequence(int[] arr)
        {
            List<int> longestSequenceOfEq = new List<int>();
            List<int> currentSequenceOfEq = new List<int>();
            currentSequenceOfEq.Add(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] == arr[i - 1])
                {
                    currentSequenceOfEq.Add(arr[i]);
                    if(i == arr.Length - 1 && currentSequenceOfEq.Count > longestSequenceOfEq.Count)
                    {
                        longestSequenceOfEq = new List<int>(currentSequenceOfEq);
                        currentSequenceOfEq.Clear();
                        currentSequenceOfEq.Add(arr[i]);
                    }
                }
                else
                {
                    if(currentSequenceOfEq.Count > longestSequenceOfEq.Count)
                    {
                        longestSequenceOfEq = new List<int>(currentSequenceOfEq);

                    }
                    currentSequenceOfEq.Clear();
                    currentSequenceOfEq.Add(arr[i]);

                }
            }
            return longestSequenceOfEq.ToArray();
        }
    }
}
