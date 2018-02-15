using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Basic_Markup_Language
{
    class Program
    {
        static void Main(string[] args)
        {
            string inversePattern = @"(.)*(inverse)(.)*([""])(?<text>.+)([""])(.)*";
            string reversePattern = @"(.)*(reverse)(.)*([""])(?<text>.+)([""])(.)*";
            string repeatPattern = @"(.)*(repeat)(.)*(value(.)*=(.)*[""](?<repTimes>[0-9]{0,2})[""])(.)*([""])(?<text>.+)([""])(.)*";

            Regex inverseRegex = new Regex(inversePattern);
            Regex reverseRegex = new Regex(reversePattern);
            Regex repeatRegex = new Regex(repeatPattern);

            int counter = 1;

            int repTimes = 0;

            string command;
            while ((command = Console.ReadLine()) != "<stop/>")
            {
                Match inverseMatch = inverseRegex.Match(command);
                Match reverseMatch = reverseRegex.Match(command);
                Match repeatMatch = repeatRegex.Match(command);

                if(inverseMatch.Success)
                {
                    string inverseText = inverseMatch.Groups["text"].Value.ToString();
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < inverseText.Length; i++)
                    {
                        char currChar = inverseText[i];
                        if (char.IsLower(currChar))
                        {
                            string toUpper = currChar.ToString().ToUpper();
                            sb.Append(toUpper);
                        }
                        else if (char.IsUpper(currChar))
                        {
                            string toLower = currChar.ToString().ToLower();
                            sb.Append(toLower);
                        }
                        else
                        {
                            sb.Append(currChar);
                        }
                    }

                    string result = sb.ToString();

                    Console.WriteLine($"{counter}. {result}");
                }
                else if(reverseMatch.Success)
                {
                    string reverseText = reverseMatch.Groups["text"].Value.ToString();
                    StringBuilder sb = new StringBuilder();

                    for (int i = reverseText.Length - 1; i >= 0; i--)
                    {
                        sb.Append(reverseText[i]);
                    }
                    string result = sb.ToString();

                    Console.WriteLine($"{counter}. {result}");
                }
                else if(repeatMatch.Success)
                {
                     repTimes = int.Parse(repeatMatch.Groups["repTimes"].Value.ToString());
                    string repeatText = repeatMatch.Groups["text"].Value.ToString();

                    for (int i = 0; i < repTimes; i++)
                    {
                        Console.WriteLine($"{counter}. {repeatText}");
                        if(i < repTimes - 1)
                        {
                            counter++;
                        }
                    }
                }
                if(reverseMatch.Success || inverseMatch.Success || (repeatMatch.Success && repTimes > 0))
                {
                    counter++;
                }
                
            }
        }
    }
}
