using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Count_Substring_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

            int counter = 0;
            int lastIndex = -1;
            while (true)
            {
                var search = input.IndexOf(word, lastIndex + 1);
                if(search != -1)
                {
                    counter++;
                    lastIndex = search;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
