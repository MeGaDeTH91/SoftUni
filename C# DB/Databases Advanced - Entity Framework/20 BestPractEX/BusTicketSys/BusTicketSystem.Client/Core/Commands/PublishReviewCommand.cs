using BusTicketSystem.Data;
using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketSystem.Client.Core.Commands
{
    public class PublishReviewCommand
    {
        public static string Execute(string[] data)
        {            
            int customerId = int.Parse(data[1]);
            double grade = double.Parse(data[2]);
            string busCompanyName = data[3];
            string content = string.Join(" ", data.Skip(4).ToArray());

            string result = string.Empty;

            using(var db = new BusTicketContext())
            {
                var customer = db.Customers
                    .Include(x => x.Reviews)
                    .Where(x => x.CustomerId == customerId)
                    .FirstOrDefault();

                var busCompany = db.BusCompanies
                    .Where(x => x.Name.ToLower() == busCompanyName.ToLower())
                    .FirstOrDefault();

                if(customer == null)
                {
                    throw new InvalidOperationException("No such user!");
                }

                if(busCompany == null)
                {
                    throw new InvalidOperationException("No such company!");
                }

                if(grade < 1 || grade > 10)
                {
                    throw new InvalidOperationException("Grade must be between 1 and 10");
                }

                var review = new Review()
                {
                    BusCompanyId = busCompany.BusCompanyId,
                    Content = content,
                    CustomerId = customerId,
                    Grade = grade
                };

                customer.Reviews.Add(review);
                db.SaveChanges();

                string fullName = customer.FirstName + " " + customer.LastName;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Customer {fullName} published review for company {busCompanyName}");

                result = sb.ToString().Trim();
            }

            return result;
        }
    }
}
