using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if(type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string max = GetMax(first, second);
                Console.WriteLine(max);
            }
        }
        static int GetMax(int first, int second)
        {
            int result = Math.Max(first, second);
            return result;
        }
        static char GetMax(char first, char second)
        {
            char result = '\0';
            if(first > second)
            {
                result = first;
            }
            else
            {
                result = second;
            }
            return result;
        }
        static string GetMax(string first, string second)
        {
            string result = string.Empty;
            if(first.CompareTo(second) > 0)
            {
                result = first;
            }
            else
            {
                result = second;
            }
            return result;
        }
    }
}
