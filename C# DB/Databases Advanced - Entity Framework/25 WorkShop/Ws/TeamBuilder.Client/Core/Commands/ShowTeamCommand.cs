namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class ShowTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            StringBuilder sb = new StringBuilder();

            using(var db = new TeamBuilderContext())
            {
                var team = db.Teams
                    .Include(x => x.UserTeams)
                    .ThenInclude(x => x.User)
                    .FirstOrDefault(x => x.Name == teamName);

                if(team == null)
                {
                    throw new ArgumentException($"Team {teamName} not found!");
                }

                sb.AppendLine($"{team.Name} {team.Acronym}");
                sb.AppendLine($"Members:");
                if(team.UserTeams.Count() == 0)
                {
                    sb.AppendLine("No members :(");
                }
                else
                {
                    foreach (var userteam in team.UserTeams)
                    {
                        sb.AppendLine($"--{userteam.User.Username}");
                    }
                }
                
            }

            return sb.ToString().Trim();
        }
    }
}
