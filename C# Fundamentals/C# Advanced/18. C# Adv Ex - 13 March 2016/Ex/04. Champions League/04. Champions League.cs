using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Champions_League
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string pattern = @"\b(?<Home>[a-zA-Z ]+)\b([ | ]+)\b(?<Away>[a-zA-Z ]+)\b([| ]+)\b(?<homescore1>[0-9]+)[:](?<awayscore1>[0-9]+)\b([ | ]+)(?<homescore2>[0-9]+)[:](?<awayscore2>[0-9]+)\b";
            Regex scoreRegex = new Regex(pattern);

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                Match currMatch = scoreRegex.Match(command);

                string teamName1 = currMatch.Groups["Home"].Value;
                string teamName2 = currMatch.Groups["Away"].Value;

                int game1HomeGoals = int.Parse(currMatch.Groups["homescore1"].Value);
                int game1AwayGoals = int.Parse(currMatch.Groups["awayscore1"].Value);

                int game2HomeGoals = int.Parse(currMatch.Groups["homescore2"].Value);
                int game2AwayGoals = int.Parse(currMatch.Groups["awayscore2"].Value);

                int totalHome = game1HomeGoals + game2AwayGoals;
                int totalAway = game1AwayGoals + game2HomeGoals;

                if (!teams.Any(x => x.Name == teamName1))
                {
                    Team team1 = new Team()
                    {
                        Name = teamName1
                    };
                    team1.Oponents.Add(teamName2);
                    teams.Add(team1);
                }
                if (!teams.Any(x => x.Name == teamName2))
                {
                    Team team2 = new Team()
                    {
                        Name = teamName2
                    };
                    team2.Oponents.Add(teamName1);
                    teams.Add(team2);
                }
                Team homeTeam = teams.FirstOrDefault(x => x.Name == teamName1);
                Team awayTeam = teams.FirstOrDefault(x => x.Name == teamName2);
                
                if(!homeTeam.Oponents.Any(x => x == teamName2))
                {
                    homeTeam.Oponents.Add(awayTeam.Name);
                }
                if(!awayTeam.Oponents.Any(x => x == teamName1))
                {
                    awayTeam.Oponents.Add(homeTeam.Name);
                }

                if(totalHome > totalAway)
                {
                    homeTeam.Wins++;
                }
                else if(totalAway > totalHome)
                {
                    awayTeam.Wins++;
                }
                else if(totalHome == totalAway)
                {
                    if(game2AwayGoals > game1AwayGoals)
                    {
                        homeTeam.Wins++;
                    }
                    else if(game1AwayGoals > game2AwayGoals)
                    {
                        awayTeam.Wins++;
                    }
                }
            }
            teams = teams.OrderByDescending(x => x.Wins).ThenBy(x => x.Name).ToList();
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- Wins: {team.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Oponents.OrderBy(x => x))}");
            }
        }
        public class Team
        {
            public string Name { get; set; }

            public int Wins { get; set; } = 0;

            public List<string> Oponents { get; set; } = new List<string>();
        }
    }
}
