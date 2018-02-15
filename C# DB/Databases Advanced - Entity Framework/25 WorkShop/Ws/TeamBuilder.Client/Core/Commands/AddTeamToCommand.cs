namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AddTeamToCommand
    {
        public string Execute(string[] inputArgs)
        {
            string eventName = inputArgs[0];
            string teamName = inputArgs[1];

            if (String.IsNullOrWhiteSpace(teamName) ||
               String.IsNullOrWhiteSpace(eventName))
            {
                throw new InvalidOperationException("Invalid data.");
            }

            AuthenticationManager.Authorize();

            using (var db = new TeamBuilderContext())
            {
                var currEvent = db.Events
                    .Include(x => x.Creator)
                    .FirstOrDefault(x => x.Name == eventName);

                var team = db.Teams
                    .FirstOrDefault(x => x.Name == teamName);

                var loggedUser = AuthenticationManager.GetCurrentUser();

                if (currEvent == null)
                {
                    throw new ArgumentException($"Event {eventName} not found!");
                }

                if (team == null)
                {
                    throw new ArgumentException($"Team {teamName} not found!");
                }

                if (loggedUser.UserId != currEvent.CreatorId)
                {
                    throw new InvalidOperationException("Not allowed!");
                }

                bool alreadyAdded = db.EventTeams
                    .Any(x => x.EventId == currEvent.EventId &&
                    x.TeamId == team.TeamId);

                if (alreadyAdded)
                {
                    throw new ArgumentException($"Cannot add same team twice!");
                }

                var eventTeam = new EventTeam()
                {
                    EventId = currEvent.EventId,
                    TeamId = team.TeamId
                };

                currEvent.ParticipatingEventTeams.Add(eventTeam);                
                db.SaveChanges();
            }
            return $"Team {teamName} added for {eventName}!";
        }
    }
}
