using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split().ToArray();

            char[] leftWord = strings[0].ToArray();
            char[] rightWord = strings[1].ToArray();
            BigInteger sum = 0;
            if (leftWord.Length == rightWord.Length)
            {
                for (long i = 0; i < leftWord.Length; i++)
                {
                    sum += leftWord[i] * rightWord[i];
                }
            }
            else if (leftWord.Length > rightWord.Length)
            {
                
                for (long i = 0; i < rightWord.Length; i++)
                {
                    sum += leftWord[i] * rightWord[i];
                }
                for (long i = rightWord.Length; i < leftWord.Length; i++)
                {
                    sum += leftWord[i];
                }
            }
            else
            {
                
                for (long i = 0; i < leftWord.Length; i++)
                {
                    sum += leftWord[i] * rightWord[i];
                }
                for (long i = leftWord.Length; i < rightWord.Length; i++)
                {
                    sum += rightWord[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
