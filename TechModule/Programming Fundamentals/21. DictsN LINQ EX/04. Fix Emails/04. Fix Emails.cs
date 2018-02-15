using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            string current = string.Empty;
            string previous = string.Empty;
            for (int i = 1; i < 100; i++)
            {
                if (i % 2 > 0)
                {
                    current = Console.ReadLine();
                    if (current == "stop")
                    {
                        var fixedmail = dict.Where(kvp => !(kvp.Value.EndsWith("us") || kvp.Value.EndsWith("uk")));
                        foreach (var item in fixedmail)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                        }
                        return;
                    }
                }
                else
                {
                    string currRes = Console.ReadLine();
                    if (dict.ContainsKey(current))
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
