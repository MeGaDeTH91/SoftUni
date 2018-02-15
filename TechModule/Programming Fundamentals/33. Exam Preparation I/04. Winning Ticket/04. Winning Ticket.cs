using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
                .Split(new char[] {',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        List<string> tickets = new List<string>();
        Dictionary<int, string> winningAMT = new Dictionary<int, string>();
        for (int i = 0; i < input.Length; i++)
            {
                tickets.Add(input[i].TrimStart().TrimEnd());
            }
        foreach (var t in tickets)
        {
            if(t.Length != 20)
            {
                Console.WriteLine($"invalid ticket");
            }
            else
            {
                var leftSide = t.Substring(0, 10);
                var rightSide = t.Substring(10);
                Match leftMatch = Regex.Match(leftSide, @"(?<dollar>([$])){6,10}|(?<diez>([#])){6,10}|(?<maimun>([@])){6,10}|(?<upper>([\^])){6,10}");
                Match rightMatch = Regex.Match(rightSide, @"(?<dollar>([$])){6,10}|(?<diez>([#])){6,10}|(?<maimun>([@])){6,10}|(?<upper>([\^])){6,10}");
                if(leftMatch.Success && rightMatch.Success)
                {
                    string leftStrM = leftMatch.ToString();
                    string rightStrM = rightMatch.ToString();
                    int minLength = Math.Min(leftStrM.Length, rightStrM.Length);
                    string winningSym = (leftStrM[0].ToString());
                    if(minLength == 10)
                    {
                        Console.WriteLine($"ticket \"{t}\" - 10{winningSym} Jackpot!");
                    }
                    else if(leftStrM[0] == rightStrM[0] && minLength >= 6)
                    {
                        Console.WriteLine($"ticket \"{t}\" - {minLength}{winningSym}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{t}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{t}\" - no match");
                }
            }
        }
     }
}