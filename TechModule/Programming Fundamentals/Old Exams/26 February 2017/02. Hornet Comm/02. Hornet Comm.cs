using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    class Privates
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    class Broadcasts
    {
        public string Message { get; set; }
        public string Frequency { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Privates> privMessage = new List<Privates>();
            List<Broadcasts> broadcasts = new List<Broadcasts>();
            string messagePattern = @"^(?<code>[0-9]+) <-> (?<message>[A-Za-z0-9]+)$";
            string broadPattern = @"^(?<message>(\D+)) <-> (?<frequency>[A-Za-z0-9]+)$";
            Regex messagess = new Regex(messagePattern);
            Regex broadcastss = new Regex(broadPattern);
            while (input != "Hornet is Green")
            {
                string[] inputArr = input
                    .Split(' ')
                    .ToArray();
                
                
                if (messagess.IsMatch(input))
                {
                    string tryRat = inputArr[2];
                    Match currM = Regex.Match(input, messagePattern);
                    Privates currPriv = new Privates();
                    string code = currM.Groups["code"].Value.ToString();
                    string message = currM.Groups["message"].Value.ToString();
                    char[] temp = code.ToCharArray();
                    Array.Reverse(temp);
                    code = new string(temp);
                    currPriv.Code = code;
                    currPriv.Message = message;
                    privMessage.Add(currPriv);
                }
                else if (broadcastss.IsMatch(input))
                {
                    Match currM = Regex.Match(input, broadPattern);
                    string curStr = currM.ToString();
                    Broadcasts currBroad = new Broadcasts();
                    string message = currM.Groups["message"].Value.ToString();
                    string currFreq = currM.Groups["frequency"].Value.ToString();
                    char[] temp = new char[currFreq.Length];
                    for (int i = 0; i < currFreq.Length; i++)
                    {
                        if(char.IsLetter(currFreq[i]))
                        {
                            if (char.IsLower(currFreq[i]))
                            {
                                temp[i] = char.ToUpper(currFreq[i]);
                            }
                            else if (char.IsUpper(currFreq[i]))
                            {
                                temp[i] = char.ToLower(currFreq[i]);
                            }
                        }
                        else
                        {
                            temp[i] = currFreq[i];
                        }
                    }
                    currBroad.Message = message;
                    currBroad.Frequency = new string(temp);
                    broadcasts.Add(currBroad);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                foreach (var broad in broadcasts)
                {
                    Console.WriteLine($"{broad.Frequency} -> {broad.Message}");
                }
            }
            else if(broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (privMessage.Count > 0)
            {
                foreach (var mess in privMessage)
                {
                    Console.WriteLine($"{mess.Code} -> {mess.Message}");
                }
            }
            else if(privMessage.Count == 0)
            {
                Console.WriteLine("None");
            }
        }
    }
}
