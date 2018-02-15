using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.Phoenix_Oscar_Romeo_November
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> squads = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Blaze it!")
            {
                string[] currCommand = input.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creature = currCommand[0];
                string squadMate = currCommand[1];

                if (creature != squadMate)
                {
                    if (squads.ContainsKey(creature))
                    {
                        if (squads[creature].All(x => x != squadMate))
                        {
                            squads[creature].Add(squadMate);
                        }
                    }
                    else
                    {
                        squads[creature] = new List<string>();
                        squads[creature].Add(squadMate);
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> printDict = new Dictionary<string, int>();
            foreach (var squad in squads)
            {
                printDict[squad.Key] = squad.Value.Count;
                
            }
            foreach (var creature in squads)
            {
                foreach (var squadMate in creature.Value)
                {
                    if (squads.ContainsKey(squadMate) && squads.ContainsKey(creature.Key) && creature.Key != squadMate)
                    {
                        if (squads[creature.Key].Any(x => x == squadMate) && squads[squadMate].Any(y => y == creature.Key))
                        {
                            printDict[creature.Key]--;
                        }
                    }
                }
            }
            foreach (var creat in printDict.OrderByDescending(x => x.Value))
            {
                
                Console.WriteLine($"{creat.Key} : {creat.Value}");
            }
        }
    }
}
