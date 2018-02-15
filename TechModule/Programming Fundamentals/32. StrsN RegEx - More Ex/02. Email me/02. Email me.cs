using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Email_me
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] sides = input.Split('@')
                .ToArray();
            char[] before = sides[0].ToCharArray();
            char[] after = sides[1].ToCharArray();
            long sumBefore = 0;
            long sumAfter = 0;
            foreach (var currLetter in before)
            {
                sumBefore += currLetter;
            }
            foreach (var currLetter in after)
            {
                sumAfter += currLetter;
            }
            if(sumBefore - sumAfter >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
