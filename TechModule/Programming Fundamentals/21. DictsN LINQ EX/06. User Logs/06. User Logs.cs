using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();
  
            var registry = new SortedDictionary<string, Dictionary<string, int>>();

            while (input[0] != "end")
            {
                string[] ipArr = input[0].Split('=').ToArray();
                string[] userArr = input[2].Split('=').ToArray();
                string currIP = ipArr[1];
                string currUser = userArr[1];
                string currMessage = input[1];
                int counter = 1;
                
                if(!registry.ContainsKey(currUser))
                {
                    registry.Add(currUser, new Dictionary<string, int>());
                }
                if(!registry[currUser].ContainsKey(currIP))
                {
                    registry[currUser].Add(currIP, counter);
                }
                else
                {
                    registry[currUser][currIP]++;
                }
                input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
            }
            foreach (var item in registry)
            {
                Console.WriteLine($"{item.Key}: ");
                foreach (var innerValue in item.Value)
                {
                    if (innerValue.Key != item.Value.Keys.Last())
                    {
                        Console.Write($"{innerValue.Key} => {innerValue.Value}, ");
                    }
                    else
                    {
                        Console.Write($"{innerValue.Key} => {innerValue.Value}. ");
                    } 
                }
                Console.WriteLine();
            }
        }
    }
}
