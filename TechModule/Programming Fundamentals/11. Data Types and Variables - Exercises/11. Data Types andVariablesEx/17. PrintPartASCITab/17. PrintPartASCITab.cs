using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.PrintPartASCITab
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

           
            for (char i = (char)('\0' + a); i <= '\0'+ b; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
