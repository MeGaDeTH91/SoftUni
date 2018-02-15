namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class KickMemberCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string username = inputArgs[1];

            if(String.IsNullOrWhiteSpace(teamName) ||
               String.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException("Invalid data.");
            }

            AuthenticationManager.Authorize();

            using (var db = new TeamBuilderContext())
            {
                var userToKick = db.Users
                    .FirstOrDefault(x => x.Username == username);

                var team = db.Teams
                    .Include(x => x.UserTeams)
                    .ThenInclude(x => x.User)
                    .FirstOrDefault(x => x.Name == teamName);

                var loggedUser = AuthenticationManager.GetCurrentUser();

                if(userToKick == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if(team == null)
                {
                    throw new ArgumentException($"Team {teamName} not found!");
                }

                if (loggedUser.UserId != team.CreatorId)
                {
                    throw new InvalidOperationException("Not allowed!");
                }

                if (team.CreatorId == userToKick.UserId)
                {
                    throw new InvalidOperationException("Command not allowed. Use DisbandTeam instead.");
                }
                
                if(!team.UserTeams.Any(x => x.UserId == userToKick.UserId))
                {
                    throw new ArgumentException($"User {username} is not a member in {teamName}!");
                }

                var userteam = db.UserTeams.FirstOrDefault(x => x.TeamId == team.TeamId &&
                x.UserId == userToKick.UserId);

                team.UserTeams.Remove(userteam);
                db.SaveChanges();
            }
            return $"User {username} was kicked from {teamName}!";
        }
    }
}
