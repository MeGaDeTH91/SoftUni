using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Teamwork_Projects
{
    class Teams
    {
        public string Name { get; set; }
        public List<string> Members { get; set; }
        public string Creator { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Teams> teamRegistry = new List<Teams>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-').ToArray();
                string currCreator = input[0];
                string currTeamName = input[1];

                Teams CurrTeam = new Teams()
                {
                    Members = new List<string>()
                };
                if (teamRegistry.Select(x => x.Name).Any(x => x == currTeamName))
                {
                    Console.WriteLine($"Team {currTeamName} was already created!");
                }
                else if(teamRegistry.Select(x => x.Creator).Any(x => x == currCreator))
                {
                    Console.WriteLine($"{currCreator} cannot create another team!");
                }
                else
                {
                    CurrTeam.Name = currTeamName;
                    CurrTeam.Creator = currCreator;
                    teamRegistry.Add(CurrTeam);
                    Console.WriteLine($"Team {currTeamName} has been created by {currCreator}!");
                }
            }

            string joinInput = Console.ReadLine();

            while (joinInput != "end of assignment")
            {
                string[] join = joinInput.Split('-','>').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                string currMembJoin = join[0];
                string currTeamJoin = join[1];

                if(teamRegistry.Select(x => x.Name).All(x => x != currTeamJoin))
                {
                    Console.WriteLine($"Team {currTeamJoin} does not exist!");
                }
                else if (teamRegistry.Select(x => x.Members).Any(x => x.Contains(currMembJoin)) ||
                    teamRegistry.Select(x => x.Creator).Contains(currMembJoin))
                {
                    Console.WriteLine($"Member {currMembJoin} cannot join team {currTeamJoin}!");
                }
                else
                {
                    int findMeTheIndex = teamRegistry.FindIndex(x => x.Name ==(currTeamJoin));
                    teamRegistry[findMeTheIndex].Members.Add(currMembJoin);
                }
                joinInput = Console.ReadLine();
            }
            foreach (var item in teamRegistry.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                if(item.Members.Count > 0)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine($"- {item.Creator}");
                    foreach (var inner in item.Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {inner}");
                    }
                }
                
            }
            Console.WriteLine("Teams to disband:");
            foreach (var item in teamRegistry.OrderBy(x => x.Name))
            {
                if(item.Members.Count == 0)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
