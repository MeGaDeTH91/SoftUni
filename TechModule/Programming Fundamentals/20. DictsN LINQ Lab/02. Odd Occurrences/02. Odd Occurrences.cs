using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToLower().Split(' ').ToArray();
            var dict = new Dictionary<string, int>();
            foreach (var item in words)
            {
                if(dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }
            bool first = true;
            foreach (var p in dict)
            {
                if(p.Value % 2 > 0)
                {
                    if(!first)
                    {
                        Console.Write(", ", p.Key);
                    }
                    Console.Write(p.Key);
                    first = false;
                }
            }
            
        }
    }
}
