using BusTicketSystem.Data;
using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketSystem.Client.Core.Commands
{
    public class BuyTicketCommand
    {
        public static string Execute(string[] data)
        {
            int customerId = int.Parse(data[1]);
            int tripId = int.Parse(data[2]);
            decimal price = decimal.Parse(data[3]);
            string seat = data[4];

            string result = string.Empty;

            using (var db = new BusTicketContext())
            {
                var customer = db.Customers
                    .Include(x => x.BankAccount)
                    .Where(x => x.CustomerId == customerId)
                    .FirstOrDefault();

                if(customer == null)
                {
                    throw new InvalidOperationException($"No such user!");
                }

                if(price <= 0)
                {
                    throw new InvalidCastException("Price cannot be negative or zero.");
                }

                customer.BankAccount.Withdraw(price);

                Ticket ticket = new Ticket()
                {
                    CustomerId = customer.CustomerId,
                    Price = price,
                    Seat = seat,
                    TripId = tripId,
                };

                if(db.Tickets.Any(x => x.CustomerId == customerId && x.TripId == tripId))
                {
                    string ticketUser = customer.FirstName + " " + customer.LastName;
                    throw new InvalidOperationException($"Customer {ticketUser} has ticket for this trip already!");
                }
                customer.Tickets.Add(ticket);
                db.SaveChanges();
                string fullName = customer.FirstName + " " + customer.LastName;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Customer {fullName} bought ticket for trip {tripId} for ${price} on seat {seat}");
                result = sb.ToString().Trim();
            }

            return result;
        }
    }
}
