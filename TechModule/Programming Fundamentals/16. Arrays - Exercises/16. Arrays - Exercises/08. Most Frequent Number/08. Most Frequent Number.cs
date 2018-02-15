using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int mostFrequent = 0;
            int repetitions = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                int currNum = numArray[i];
                int counter = 0;
                for (int j = 0; j < numArray.Length; j++)
                {
                    if (currNum == numArray[j])
                    {
                        counter++;

                    }
                }
                if(counter > repetitions)
                {
                    mostFrequent = currNum;
                    repetitions = counter;
                }
            }
            Console.WriteLine(mostFrequent);
        }
    }
}
