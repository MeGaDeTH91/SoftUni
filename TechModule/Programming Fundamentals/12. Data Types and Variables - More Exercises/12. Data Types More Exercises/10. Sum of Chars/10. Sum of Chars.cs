using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numLines = byte.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= numLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int intLetter = Convert.ToInt32(letter);
                sum =  sum + intLetter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
