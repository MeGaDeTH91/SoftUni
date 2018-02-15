using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _08.Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=<)(?<bombPower>.{2})(?=>)";
            string input = Console.ReadLine();
            int bombPower = 0;
            int leftBord = 0;
            int rightBord = 0;
            string result = string.Empty;
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
            {
                string currMatch = m.ToString();
                char[] bombChars = currMatch.ToCharArray();
                bombPower = Math.Abs(bombChars[0] - bombChars[1]);
                char[] inputChars = input.ToCharArray();
                int index = input.IndexOf(currMatch) - 1;
                leftBord = index - bombPower;
                if(leftBord <0)
                {
                    leftBord = 0;
                }
                rightBord = index + bombPower + 4;
                if (rightBord >= inputChars.Length)
                {
                    rightBord = inputChars.Length;
                }
                for (int i = leftBord; i < rightBord; i++)
                {
                    inputChars[i] = '_';
                }
                input = new string(inputChars);
            }
            Console.WriteLine(input);
        }
    }
}
