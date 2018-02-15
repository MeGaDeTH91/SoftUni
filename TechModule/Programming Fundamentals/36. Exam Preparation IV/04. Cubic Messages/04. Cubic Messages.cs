using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> validOnes = new Dictionary<string, string>();
            string pattern = @"^(?<numsBefore>[0-9]+)(?<message>[A-Za-z]+)(?<numsAfter>[^A-Za-z]+)*$";

            string currMessage = Console.ReadLine();
            string initialMessage = string.Empty;
            string encriptedMess = string.Empty;
            while (currMessage != "Over!")
            {
                if(currMessage == "Over!")
                {
                    break;
                }
                StringBuilder messageBuilder = new StringBuilder();
                string currentMess = string.Empty;
                int messLength = int.Parse(Console.ReadLine());
                Match currMatch = Regex.Match(currMessage, pattern);
                if(currMatch.Success && currMatch.Groups["message"].Value.ToString().Length == messLength)
                { 
                    currentMess = currMatch.Groups["message"].Value.ToString();
                    char[] messToChar = currentMess.ToCharArray();
                    char[] beforeNums = currMatch.Groups["numsBefore"].Value.ToCharArray();
                    char[] afterNums = currMatch.Groups["numsAfter"].Value.ToCharArray();
                    for (int i = 0; i < beforeNums.Length; i++)
                    {
                        int currIndex = 0;
                        if(char.IsDigit(beforeNums[i]))
                        {
                            currIndex = int.Parse(beforeNums[i].ToString());
                            if(currIndex >= 0 && currIndex < messToChar.Length)
                            {
                                messageBuilder.Append(messToChar[currIndex]);
                            }
                            else
                            {
                                messageBuilder.Append(" ");
                            }
                        }
                    }
                    for (int i = 0; i < afterNums.Length; i++)
                    {
                        int currIndex = 0;
                        if (char.IsDigit(afterNums[i]))
                        {
                            currIndex = int.Parse(afterNums[i].ToString());
                            if (currIndex >= 0 && currIndex < messToChar.Length)
                            {
                                messageBuilder.Append(messToChar[currIndex]);
                            }
                            else
                            {
                                messageBuilder.Append(" ");
                            }
                        }
                        
                    }
                    initialMessage = new string(messToChar);
                    encriptedMess = messageBuilder.ToString();
                    if(!validOnes.ContainsKey(initialMessage))
                    {
                        validOnes[initialMessage] = encriptedMess;
                    }
                    else
                    {
                        validOnes[initialMessage] = encriptedMess;
                    }
                }
               

                currMessage = Console.ReadLine();
            }
            foreach (var message in validOnes)
            {
                Console.WriteLine($"{message.Key} == {message.Value}");
            }
        }
    }
}
