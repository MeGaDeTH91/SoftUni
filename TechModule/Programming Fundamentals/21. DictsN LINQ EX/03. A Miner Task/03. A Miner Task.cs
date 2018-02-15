using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            string current = string.Empty;
            string previous = string.Empty;
            for (int i = 1; i < 100; i++)
            {
                if(i % 2 > 0)
                {
                    current = Console.ReadLine();
                    if(current == "stop")
                    {
                        foreach (var item in dict)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                            
                        }
                        return;
                    }
                }
                else
                {
                    int currRes = int.Parse(Console.ReadLine());
                    if(dict.ContainsKey(current))
                    {
                        var newValue = dict[current] + currRes; 
                        dict[current] = newValue;
                    }
                    else
                    {
                        dict.Add(current, currRes);
                    }
                    
                }
            } 
        }
    }
}
