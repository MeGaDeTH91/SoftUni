namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string acronym = inputArgs[1];

            if(string.IsNullOrWhiteSpace(teamName) ||
                string.IsNullOrWhiteSpace(acronym))
            {
                throw new InvalidOperationException("Invalid data.");
            }

            AuthenticationManager.Authorize();

            if(acronym.Length != 3)
            {
                throw new ArgumentException($"Acronym {acronym} not valid!");
            }

            using(var db = new TeamBuilderContext())
            {
                if(db.Teams.Any(x => x.Name == teamName))
                {
                    throw new ArgumentException($"Team {teamName} exists!");
                }

                var user = AuthenticationManager.GetCurrentUser();

                Team team = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    CreatorId = user.UserId
                };
                db.Teams.Add(team);
                db.SaveChanges();
            }

            return $"Team {teamName} successfully created!";
        }
    }
}
