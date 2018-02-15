using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Trainegram
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^((<\[)([^A-Za-z0-9])*?([\]].)(\.\[([A-Za-z0-9])*?\]\.)*)$";

            Regex myRgx = new Regex(pattern);
            string input = Console.ReadLine();

            while (input != "Traincode!")
            {
                Match match = myRgx.Match(input);
                if(match.Success)
                {
                    string res = match.ToString();
                    Console.WriteLine(res);
                }

                input = Console.ReadLine();
            }
            
            
           
        }
    }
}
