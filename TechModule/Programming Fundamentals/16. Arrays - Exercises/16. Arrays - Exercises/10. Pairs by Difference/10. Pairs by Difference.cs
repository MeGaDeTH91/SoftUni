using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                for (int j = 0; j < numArray.Length; j++)
                {
                    if(numArray[i] - numArray[j] == diff)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
