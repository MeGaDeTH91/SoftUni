using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([0-9]+)(?<text>[a-zA-Z]+)(?<after>[^a-zA-Z]*)$";
            Regex regex = new Regex(pattern);

            

            string command;
            while ((command = Console.ReadLine()) != "Over!")
            {
                int currLength = int.Parse(Console.ReadLine());

                StringBuilder sb = new StringBuilder();

                Match currMatch = regex.Match(command);
                string numsBefore = currMatch.Groups[1].Value;
                string currMessage = currMatch.Groups["text"].Value;
                string numsAfter = currMatch.Groups["after"].Value;

                List<int> digits = new List<int>();
                ExtractNumbers(numsBefore, ref digits);
                ExtractNumbers(numsAfter, ref digits);

                if(currMessage.Length == currLength)
                {
                    foreach (var num in digits)
                    {
                        if(num >= 0 && num < currMessage.Length)
                        {
                            sb.Append(currMessage[num]);
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                    }
                    Console.WriteLine($"{currMessage} == {sb.ToString()}");
                }
            }
           
        }

        private static void ExtractNumbers(string numsBefore, ref List<int> digits)
        {
            for (int i = 0; i < numsBefore.Length; i++)
            {
                if (char.IsDigit(numsBefore[i]))
                {
                    digits.Add(int.Parse(numsBefore[i].ToString()));
                }
            }
        }
    }
}
