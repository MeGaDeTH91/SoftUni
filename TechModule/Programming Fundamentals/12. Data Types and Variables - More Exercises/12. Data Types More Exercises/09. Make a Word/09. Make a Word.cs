using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            byte num = byte.Parse(Console.ReadLine());

            string word = string.Empty;
            for (int i = 1; i <= num; i++)
            {
                string letters = Console.ReadLine();
                word = word + letters;
            }
            Console.WriteLine($"The word is: {word}");
        }
    }
}
