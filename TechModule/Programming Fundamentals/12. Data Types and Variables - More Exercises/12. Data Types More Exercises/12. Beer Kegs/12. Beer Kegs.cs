using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            

            
            string sumWord = string.Empty;

            decimal biggest = 1;
            decimal result = 0.0m;
            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                decimal radius = decimal.Parse(Console.ReadLine());
                long height = int.Parse(Console.ReadLine());

                result = 3.1415926535897931m * radius * radius * height;
                decimal currentBiggest = biggest;
                biggest = (decimal)(Math.Max(biggest, result));
                if(currentBiggest != biggest)
                {
                    sumWord = name;
                }
            }
            Console.WriteLine(sumWord);
        }
    }
}
