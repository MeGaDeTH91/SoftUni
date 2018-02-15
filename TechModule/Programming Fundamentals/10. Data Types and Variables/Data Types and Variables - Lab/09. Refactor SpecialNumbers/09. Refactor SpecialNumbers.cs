using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstdigit = 0;
            int secondigit = 0;
            int result = 0;
            bool state = false;
            for (int currentNum = 1; currentNum <= n; currentNum++)
            {
               var i = currentNum;
                
                while (i > 0)
                {
                    result = result + i % 10;
                    i = i / 10;
                }
                //result = secondigit + firstdigit;
                state = (result == 5) || (result == 7) || (result == 11);
                Console.WriteLine($"{currentNum} -> {state}");
                result = 0;
                i = currentNum;
               
            }

        }
    }
}
