using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Morse_Code_Upgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine()
                .Split('|')
                .Where(x => x.Length > 0)
                .ToArray();
            string pattern = @"([1]{2,100})|([0]{2,100})*";
            string finalWord = string.Empty;
            foreach (var currLetter in letters)
            {
                MatchCollection currMatch = Regex.Matches(currLetter, pattern);
                string matchLenght = string.Empty;
                foreach (Match match in currMatch)
                {
                    matchLenght += match.ToString();
                }
                
                int currAdd = 0;
                long currLettSum = 0;
                for (int i = 0; i < currLetter.Length; i++)
                {
                    currAdd = int.Parse(currLetter[i].ToString());
                    if(currAdd == 0)
                    {
                        currLettSum += 3;
                    }
                    else if(currAdd == 1)
                    {
                        currLettSum += 5;
                    }
                }
                if(matchLenght.Length>0)
                {
                    currLettSum += matchLenght.Length;
                }
                char currChar = Convert.ToChar(currLettSum);
                finalWord += currChar.ToString();
            }
            Console.WriteLine(finalWord);
        }
    }
}
