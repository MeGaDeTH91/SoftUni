using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.String_Concaten
{
    class Program
    {
        static void Main(string[] args)
        {
            char separator = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            byte n = byte.Parse(Console.ReadLine());

            string sumWord = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                if(evenOrOdd == "even" && i % 2 == 0)
                {
                    sumWord = sumWord + word + $"{separator}";
                }
                if (evenOrOdd == "odd" && i % 2 > 0)
                {
                    sumWord = sumWord +  word + $"{separator}";
                }
            }
            sumWord = sumWord.Remove(sumWord.Length - 1);
            Console.WriteLine(sumWord);
        }
    }
}
