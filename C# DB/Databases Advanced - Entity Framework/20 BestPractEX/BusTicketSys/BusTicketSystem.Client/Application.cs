using BusTicketSystem.Client.Core;
using BusTicketSystem.Data;
using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusTicketSystem.Client
{
    class Application
    {
        static void Main(string[] args)
        {
            //using (var context = new BusTicketContext())
            //{
            //    ResetDatabase(context);
            //}

            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }

        private static void ResetDatabase(BusTicketContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            //context.Database.EnsureCreated();
            Seed(context);
            Console.WriteLine($"Migrations with custom Constraints applied!");
            Console.WriteLine("Seeded Successfully!");
            Console.WriteLine("Reset Database: Success!");
        }

        private static void Seed(BusTicketContext context)
        {
            
            var towns = new List<Town>()
            {
                new Town()
                {
                    Name = "Kyustendil",
                    Country = "Bulgaria",
                },
                new Town()
                {
                    Name = "Sofia",
                    Country = "Bulgaria",
                },
                new Town()
                {
                    Name = "Blagoevgrad",
                    Country = "Bulgaria",
                },
                new Town()
                {
                    Name = "Burgas",
                    Country = "Bulgaria",
                },
                new Town()
                {
                    Name = "Ruse",
                    Country = "Bulgaria",
                },
            };
            context.AddRange(towns);
            context.SaveChanges();

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "Cool1",
                    LastName = "Guy1",
                    HomeTownId = 1,
                    Gender = CustomerGender.Male
                },
                new Customer()
                {
                    FirstName = "Cool1",
                    LastName = "Girl1",
                    HomeTownId = 1,
                    Gender = CustomerGender.Female
                },
                new Customer()
                {
                    FirstName = "Cool2",
                    LastName = "Guy2",
                    HomeTownId = 2,
                    Gender = CustomerGender.Male
                },
                new Customer()
                {
                    FirstName = "Cool2",
                    LastName = "Girl2",
                    HomeTownId = 2,
                    Gender = CustomerGender.Female
                },
                new Customer()
                {
                    FirstName = "Cool3",
                    LastName = "Unknown3",
                    HomeTownId = 3,
                    Gender = CustomerGender.NotSpecified
                },
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var bankAccounts = new List<BankAccount>()
            {
               new BankAccount()
               {
                   AccountNumber = "Us1",
                   Balance = 100,
                   CustomerId = 1
               },
               new BankAccount()
               {
                   AccountNumber = "Us2",
                   Balance = 200,
                   CustomerId = 2
               },
               new BankAccount()
               {
                   AccountNumber = "Us3",
                   Balance = 300,
                   CustomerId = 3
               },
               new BankAccount()
               {
                   AccountNumber = "Us4",
                   Balance = 400,
                   CustomerId = 4
               },
               new BankAccount()
               {
                   AccountNumber = "Us5",
                   Balance = 500,
                   CustomerId = 5
               },
            };
            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();

            var reviews = new List<Review>()
            {
                new Review()
                {
                    BusCompanyId = 1,
                    Content = "It was not bad trip",
                    CustomerId = 1,
                    Grade = 5.5
                },
                new Review()
                {
                    BusCompanyId = 1,
                    Content = "It was a bad trip",
                    CustomerId = 1,
                    Grade = 2.0
                },
                new Review()
                {
                    BusCompanyId = 1,
                    Content = "It was very bad trip",
                    CustomerId = 2,
                    Grade = 1.5
                },
                new Review()
                {
                    BusCompanyId = 2,
                    Content = "It was awesome trip",
                    CustomerId = 2,
                    Grade = 8.5
                },
                new Review()
                {
                    BusCompanyId = 3,
                    Content = "It was average trip",
                    CustomerId = 3,
                    Grade = 5.5
                },

            };
            context.Reviews.AddRange(reviews);

            var busCompanies = new List<BusCompany>()
            {
                new BusCompany()
                {
                    Name = "Union",
                    Nationality = "BG",
                },
                new BusCompany()
                {
                    Name = "Datsi",
                    Nationality = "BG"
                },
                new BusCompany()
                {
                    Name = "RussianBuses",
                    Nationality = "RS"
                },
                new BusCompany()
                {
                    Name = "Vodka",
                    Nationality = "RS"
                },
                new BusCompany()
                {
                    Name = "UnitedLines",
                    Nationality = "US"
                },
            };
            context.BusCompanies.AddRange(busCompanies);
            context.SaveChanges();

            var busComsForRating =context.BusCompanies
                 .Include(x => x.Reviews)
                 .ToList();
            foreach (var company in busComsForRating)
            {
                double rating = 0.0d;
                if(company.Reviews.Count > 0)
                {
                    rating = company.Reviews.Average(x => x.Grade);

                    company.Rating = rating;
                }
                else
                {
                    company.Rating = 0.0d;
                }
                
            }
            context.SaveChanges();

            var busStations = new List<BusStation>()
            {
                new BusStation()
                {
                    Name = "Kyustendil Centre",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Kyustendil 2",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Sofia Centre",
                    TownId = 2
                },
                new BusStation()
                {
                    Name = "Sofia 2",
                    TownId = 2
                },
                new BusStation()
                {
                    Name = "Blagoevgrad Centre",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Blagoevgrad 2",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Burgas Centre",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Burgas 2",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Ruse Centre",
                    TownId = 1
                },
                new BusStation()
                {
                    Name = "Ruse 2",
                    TownId = 1
                },
            };
            context.BusStations.AddRange(busStations);
            context.SaveChanges();

            var trips = new List<Trip>()
            {
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 08:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 09:00"),
                    BusCompanyId = 1,
                    OriginBusStationId = 1,
                    DestinationBusStationId = 4,
                    Status = TripStatus.Arrived
                },
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 08:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 09:00"),
                    BusCompanyId = 1,
                    OriginBusStationId = 2,
                    DestinationBusStationId = 1,
                    Status = TripStatus.Arrived
                },
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 09:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 10:00"),
                    BusCompanyId = 2,
                    OriginBusStationId = 2,
                    DestinationBusStationId = 4,
                    Status = TripStatus.Delayed
                },
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 09:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 10:00"),
                    BusCompanyId = 2,
                    OriginBusStationId = 5,
                    DestinationBusStationId = 1,
                    Status = TripStatus.Delayed
                },
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 10:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 11:00"),
                    BusCompanyId = 3,
                    OriginBusStationId = 1,
                    DestinationBusStationId = 7,
                    Status = TripStatus.Cancelled
                },
                new Trip()
                {
                    DepartureTime = DateTime.Parse("12-10-2017 10:00"),
                    ArrivalTime = DateTime.Parse("12-10-2017 11:00"),
                    BusCompanyId = 3,
                    OriginBusStationId = 7,
                    DestinationBusStationId = 3,
                    Status = TripStatus.Cancelled
                },
            };
            context.Trips.AddRange(trips);
            context.SaveChanges();

            var tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    CustomerId = 1,
                    Price = 10.00m,
                    Seat = "A1",
                    TripId = 1
                },
                new Ticket()
                {
                    CustomerId = 2,
                    Price = 10.00m,
                    Seat = "A2",
                    TripId = 1
                },
                new Ticket()
                {
                    CustomerId = 3,
                    Price = 10.00m,
                    Seat = "B1",
                    TripId = 2
                },
                new Ticket()
                {
                    CustomerId = 4,
                    Price = 10.00m,
                    Seat = "B2",
                    TripId = 2
                },
                new Ticket()
                {
                    CustomerId = 5,
                    Price = 10.00m,
                    Seat = "C5",
                    TripId = 3
                },
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
