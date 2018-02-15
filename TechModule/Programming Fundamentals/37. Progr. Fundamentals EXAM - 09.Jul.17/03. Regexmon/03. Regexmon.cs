using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string didiMonPattern = @"[^A-Za-z-]+";
            string bojoMonPattern = @"([A-Za-z]+[-][A-Za-z]+)";

            string input = Console.ReadLine();
            bool didiTurn = true;

            while (input.Length != 0)
            {
                Match didiMatch = Regex.Match(input, didiMonPattern);
                if (didiTurn && didiMatch.Success)
                {
                        string currMatch = didiMatch.ToString();
                        int indexOfMatch = input.IndexOf(currMatch);
                        input = input.Substring((input.IndexOf(currMatch)) + currMatch.Length, input.Length - currMatch.Length - (input.IndexOf(currMatch)));
                        Console.WriteLine(currMatch);
                        didiTurn = false;
                }
                Match bojoMatch = Regex.Match(input, bojoMonPattern);
                if (!didiTurn && bojoMatch.Success)
                {
                        string currMatch = bojoMatch.ToString();
                        int indexOfMatch = input.IndexOf(currMatch);
                        input = input.Substring((input.IndexOf(currMatch)) + currMatch.Length, input.Length - currMatch.Length - (input.IndexOf(currMatch)));
                        Console.WriteLine(currMatch);

                        didiTurn = true;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
