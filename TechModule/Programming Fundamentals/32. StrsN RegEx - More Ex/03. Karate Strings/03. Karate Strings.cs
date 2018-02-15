using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Karate_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder path = new StringBuilder(Console.ReadLine());
            int power = 0;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                if(path[i] == '>')
                {
                    i++;
                    power += int.Parse(path[i].ToString());
                    while (i< path.Length && power > 0)
                    {
                        if(path[i] == '>')
                        {
                            break;
                        }
                        path.Remove(i, 1);
                        power--;
                    }
                    i--;
                }
            }
            
            Console.WriteLine(path);
        }
    }
}
