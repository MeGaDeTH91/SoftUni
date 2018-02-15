using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numArr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long numCheck = long.Parse(Console.ReadLine());
            bool isFound = false;
            long sum = long.MaxValue;
            for (long i = 0; i < numArr.Length; i++)
            {
                if(numArr[i] == numCheck && (sum != 0))
                {
                    isFound = true;
                    sum = 0;
                    for (long k = 0; k < i; k++)
                    {
                        sum += numArr[k];
                    }
                }
                else if (numArr[i] == numCheck)
                {
                    isFound = true;
                  
                    for (long k = 0; k < i; k++)
                    {
                        sum += numArr[k];
                    }
                }
            }
            if(isFound)
            {
                Console.WriteLine(sum); 
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
