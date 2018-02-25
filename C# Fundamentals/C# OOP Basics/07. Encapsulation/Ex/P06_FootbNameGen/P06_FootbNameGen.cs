using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_FootbNameGen
{
    class P06_FootbNameGen
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commTokens = command.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    string currAction = commTokens[0];

                    switch (currAction)
                    {
                        case "Team":
                            string addTeamName = commTokens[1];
                            Team addTeam = new Team(addTeamName);
                            teams.Add(addTeam);
                            break;
                        case "Add":
                            string teamNameToImport = commTokens[1];
                            string playerNameToAdd = commTokens[2];
                            int currEndurance = int.Parse(commTokens[3]);
                            int currSprint = int.Parse(commTokens[4]);
                            int currDribble = int.Parse(commTokens[5]);
                            int currPassing = int.Parse(commTokens[6]);
                            int currShooting = int.Parse(commTokens[7]);

                            var teamToImportPlayer = teams.FirstOrDefault(x => x.TeamName == teamNameToImport);
                            if(teamToImportPlayer == null)
                            {
                                throw new ArgumentException($"Team {teamNameToImport} does not exist.");
                            }

                            Player addPlayer = new Player(playerNameToAdd, currEndurance, currSprint, currDribble, currPassing, currShooting);

                            teamToImportPlayer.AddPlayer(addPlayer);
                            break;
                        case "Remove":
                            string removeTeamName = commTokens[1];
                            string removePlayerName = commTokens[2];

                            var teamToRemoveFrom = teams.FirstOrDefault(x => x.TeamName == removeTeamName);

                            if (teamToRemoveFrom == null)
                            {
                                throw new ArgumentException($"Team {removeTeamName} does not exist.");
                            }
                            var playerToRemove = teamToRemoveFrom.GetMeThePlayer(removePlayerName);
                            if(playerToRemove == null)
                            {
                                throw new ArgumentException($"Player {removePlayerName} is not in {removeTeamName} team.");
                            }

                            teamToRemoveFrom.RemoveMeThePlayer(playerToRemove);

                            break;
                        case "Rating":
                            string teamNameRating = commTokens[1];

                            var teamToPrintRating = teams.FirstOrDefault(x => x.TeamName == teamNameRating);

                            if(teamToPrintRating == null)
                            {
                                throw new ArgumentException($"Team {teamNameRating} does not exist.");
                            }

                            Console.WriteLine($"{teamToPrintRating.TeamName} - {teamToPrintRating.Rating:F0}");
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
