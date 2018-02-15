using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.BalancedBracket
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openingBracket = 0;
            int closingBracket = 0;
            string lastString = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                string randomString = Console.ReadLine();
                if(randomString == "(")
                {
                    openingBracket++;
                    lastString = "" + randomString;
                }
                else if(randomString == ")")
                {
                    closingBracket++;
                    lastString = "" + randomString;
                }
            }
            if (lastString == "(")
            {
                Console.WriteLine("UNBALANCED");
            }
            else if (openingBracket == closingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else if(openingBracket != closingBracket)
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
