namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class DisbandCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            AuthenticationManager.Authorize();

            using(var db = new TeamBuilderContext())
            {
                var team = db.Teams
                    .FirstOrDefault(x => x.Name == teamName);

                var loggedUser = AuthenticationManager.GetCurrentUser();

                if (team == null)
                {
                    throw new ArgumentException($"Team {teamName} not found!");
                }

                if (loggedUser.UserId != team.CreatorId)
                {
                    throw new InvalidOperationException("Not allowed!");
                }

                var invitations = db.Invitations
                    .Where(x => x.TeamId == team.TeamId);
                db.Invitations.RemoveRange(invitations);
                db.Teams.Remove(team);
                db.SaveChanges();
            }

            return $"{teamName} has disbanded!";
        }
    }
}
