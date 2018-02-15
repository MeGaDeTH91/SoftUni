namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class InviteToTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string username = inputArgs[1];

            if (String.IsNullOrWhiteSpace(teamName) ||
               String.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException("Invalid data.");
            }

            AuthenticationManager.Authorize();

            using (var db = new TeamBuilderContext())
            {
                var userToInvite = db.Users
                    .FirstOrDefault(x => x.Username == username);

                var team = db.Teams
                    .FirstOrDefault(x => x.Name == teamName);

                var loggedUser = AuthenticationManager.GetCurrentUser();

                if (userToInvite == null || team == null)
                {
                    throw new ArgumentException($"Team or user does not exist!");
                }

                if (loggedUser.UserId != team.CreatorId &&
                    !team.UserTeams.Any(x => x.UserId == loggedUser.UserId)
                    || team.UserTeams.Any(x => x.UserId == userToInvite.UserId))
                {
                    throw new InvalidOperationException("Not allowed!");
                }

                bool alreadyInvited = db.Invitations.Any(x => x.InvitedUserId == userToInvite.UserId && x.TeamId == team.TeamId && x.IsActive == true);

                if (alreadyInvited)
                {
                    throw new InvalidOperationException("Invite is already sent!");
                }

                var invitation = new Invitation()
                {
                    TeamId = team.TeamId,
                    InvitedUserId = userToInvite.UserId,
                    IsActive = true
                };

                team.Invitations.Add(invitation);
                db.SaveChanges();
            }
            return $"Team {teamName} invited {username}!";
        }
    }
}
