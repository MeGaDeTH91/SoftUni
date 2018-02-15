using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands
{
    public class CreateEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(6, inputArgs);

            string name = inputArgs[0];
            if(name.Length > 25 || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid event name!");
            }

            string description = inputArgs[1];
            if (description.Length > 250 || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Invalid event description!");
            }

            AuthenticationManager.Authorize();

            var user = AuthenticationManager.GetCurrentUser();
            StringBuilder start = new StringBuilder();
            start.Append($"{inputArgs[2]} {inputArgs[3]}");
            string tryParseStartDate = start.ToString().Trim();
            StringBuilder end = new StringBuilder();
            end.Append($"{inputArgs[4]} {inputArgs[5]}");
            string tryParseEndDate = end.ToString().Trim();

            DateTime startDate;
            bool isValidStartDate = DateTime.TryParseExact(tryParseStartDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            DateTime endDate;
            bool isValidEndDate = DateTime.TryParseExact(tryParseEndDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!isValidStartDate || !isValidEndDate)
            {
                throw new ArgumentException("Please insert the dates in format: [dd/MM/yyyy HH:mm]!");
            }

            if(startDate > endDate)
            {
                throw new ArgumentException("Start date should be before end date.");
            }

            using(var db = new TeamBuilderContext())
            {
                db.Entry(user).State = EntityState.Unchanged;

                Event currEvent = new Event()
                {
                    Name = name,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = user.UserId
                };
                db.Events.Add(currEvent);
                db.SaveChanges();
            }

            return $"Event {name} created successfully!";
        }
    }
}
