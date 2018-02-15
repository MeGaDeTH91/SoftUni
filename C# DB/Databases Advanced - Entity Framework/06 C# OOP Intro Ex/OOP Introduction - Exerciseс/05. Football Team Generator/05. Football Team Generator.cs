using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split(';').ToArray();
            try
            {
                if (args.Length == 2)
                {
                    if (args[0].ToLower() == "team")
                    {
                        Team currTeam = new Team();
                        currTeam.Name = args[1];
                        teams.Add(currTeam);
                    }
                    else if (args[0].ToLower() == "rating")
                    {
                        string teamName = args[1];
                        if (teams.All(x => x.Name != teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Team searched = teams.First(x => x.Name == teamName);
                            decimal rating = teams.First(x => x.Name == teamName).CalculateRating(teamName);
                            Console.WriteLine($"{teamName} - {rating:F0}");
                        }

                    }
                }

                else if (args[0].ToLower() == "remove")
                {
                    string teamName = args[1];
                    Team currTeam = teams.First(x => x.Name == teamName);
                    string playerName = args[2];
                    if (teams.All(x => x.Name != teamName))
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }
                    if (currTeam.Players.All(x => x.Name != playerName))
                    {
                        throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                    }
                    else
                    {
                        teams.First(x => x.Name == teamName).PlayerRemoval(teamName, playerName);
                    }
                }
                else if (args[0].ToLower() == "add")
                {
                    string teamName = args[1];
                    if (teams.All(x => x.Name != teamName))
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }
                    Player currPlayer = new Player();
                    currPlayer.Name = args[2];
                    currPlayer.Endurance = int.Parse(args[3]);
                    currPlayer.Sprint = int.Parse(args[4]);
                    currPlayer.Dribble = int.Parse(args[5]);
                    currPlayer.Passing = int.Parse(args[6]);
                    currPlayer.Shooting = int.Parse(args[7]);
                    currPlayer.AvgStats = currPlayer.AverageStats();
                    teams.First(x => x.Name == teamName).Players.Add(currPlayer);
                    decimal rating = teams.First(x => x.Name == teamName).CalculateRating(teamName);
                    teams.First(x => x.Name == teamName).Rating = rating;
                }
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        
    }
}