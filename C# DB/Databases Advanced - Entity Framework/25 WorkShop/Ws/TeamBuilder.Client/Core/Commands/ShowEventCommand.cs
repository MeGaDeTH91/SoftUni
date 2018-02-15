namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class ShowEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            string eventName = inputArgs[0];

            StringBuilder sb = new StringBuilder();

            using (var db = new TeamBuilderContext())
            {
                var currEvent = db.Events
                    .Include(x => x.ParticipatingEventTeams)
                    .ThenInclude(y => y.Team)
                    .FirstOrDefault(x => x.Name == eventName);


                if (currEvent == null)
                {
                    throw new ArgumentException($"Event {eventName} not found!");
                }
                var formatedStart = currEvent.StartDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var formatedEnd = currEvent.EndDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                sb.AppendLine($"{currEvent.Name} {formatedStart} {formatedEnd}");
                sb.AppendLine($"{currEvent.Description}");
                sb.AppendLine($"Teams:");
                if (currEvent.ParticipatingEventTeams.Count() == 0)
                {
                    sb.AppendLine("No teams :(");
                }
                else
                {
                    foreach (var eventTeam in currEvent.ParticipatingEventTeams)
                    {
                        sb.AppendLine($"-{eventTeam.Team.Name}");
                    }
                }

            }

            return sb.ToString().Trim();
        }
    }
}
