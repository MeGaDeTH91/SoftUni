using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Incr_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
           
            int startIndex = 0;
            int seqLen = 1;

            int bestStartIndex = 0;
            int bestSeqLenght = 0;
            for (int i = 1; i < numArray.Length; i++)
            {

                if (numArray[i] > numArray[i - 1])
                {
                    seqLen++;

                    if (seqLen > bestSeqLenght)
                    {

                        bestStartIndex = startIndex;
                        bestSeqLenght = seqLen;
                    }
                }
                else
                {

                    startIndex = i;

                    seqLen = 1;

                }
            }
            for (int i = bestStartIndex; i < bestStartIndex + bestSeqLenght; i++)
            {
                Console.Write(numArray[i] + " ");
            }
            if (bestSeqLenght == 0)
            {
                Console.WriteLine(numArray[0]);
            }
        }
    }
}
