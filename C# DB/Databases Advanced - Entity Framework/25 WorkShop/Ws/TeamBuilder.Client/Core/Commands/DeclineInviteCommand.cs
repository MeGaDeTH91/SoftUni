﻿namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DeclineInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string username;

            if (String.IsNullOrWhiteSpace(teamName))
            {
                throw new InvalidOperationException("Invalid data.");
            }

            AuthenticationManager.Authorize();

            using (var db = new TeamBuilderContext())
            {
                var team = db.Teams
                    .FirstOrDefault(x => x.Name == teamName);

                var loggedUser = AuthenticationManager.GetCurrentUser();

                username = loggedUser.Username;

                if (team == null)
                {
                    throw new ArgumentException($"Team {teamName} not found!");
                }

                bool invitationExists = db.Invitations
                    .Any(x => x.InvitedUserId == loggedUser.UserId &&
                    x.TeamId == team.TeamId && x.IsActive == true);

                if (!invitationExists)
                {
                    throw new InvalidOperationException($"Invite from {teamName} is not found!");
                }

                var invitation = db.Invitations
                    .FirstOrDefault(x => x.TeamId == team.TeamId &&
                    x.InvitedUserId == loggedUser.UserId);

                invitation.IsActive = false;
                db.SaveChanges();
            }
            return $"Invite from {teamName} declined.";
        }
    }
}
