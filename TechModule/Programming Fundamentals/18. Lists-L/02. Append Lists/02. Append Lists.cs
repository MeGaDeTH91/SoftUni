using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|').ToArray();

            List <string> numbers = new List<string>();
            Array.Reverse(input);
            foreach (var token in input)
            {
                string[] num = token.Split(' ');
                for (int i = 0; i < num.Length; i++)
                {
                    if(num[i] != " ")
                    {
                        numbers.Add(num[i]);
                    }
                }
                
            }
            
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
