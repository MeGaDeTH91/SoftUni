using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BusTicketSystem.Client.Core.Commands
{
    public class PrintReviewsCommand
    {
        public static string Execute(string[] data)
        {
            string result = string.Empty;

            int busCompanyId = int.Parse(data[1]);

            using(var db = new BusTicketContext())
            {
                var reviews = db.Reviews
                    .Include(x => x.Customer)
                    .Where(x => x.BusCompanyId == busCompanyId)
                    .ToList();

                if (reviews.Count < 1)
                {
                    throw new InvalidOperationException($"No reviews for this Bus Company.");
                }

                    StringBuilder sb = new StringBuilder();

                foreach (var rev in reviews)
                {
                    string custFullName = rev.Customer.FirstName + " " + rev.Customer.LastName;

                    string dateTime = rev.PublishDate.ToString(@"yyyy/MM/dd HH:mm",CultureInfo.InvariantCulture);

                    sb.AppendLine($"{rev.ReviewId} {rev.Grade} {dateTime}");
                    sb.AppendLine($"{custFullName}");
                    sb.AppendLine($"{rev.Content}");
                    
                }
                result = sb.ToString().Trim();
            }

            return result;
        }
    }
}
