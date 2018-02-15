using BusTicketSystem.Data;
using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BusTicketSystem.Client.Core.Commands
{
    public class ChangeTripStatusCommand
    {
        public static string Execute(string[] data)
        {
            int tripId = int.Parse(data[1]);
            string newStatus = data[2].ToLower();

            string result = string.Empty;

            using(var db = new BusTicketContext())
            {
                var trip = db.Trips
                    .Include(x => x.OriginBusStation)
                    .ThenInclude(x => x.Town)
                    .Include(x => x.DestinationBusStation)
                    .ThenInclude(x => x.Town)
                    .Include(x => x.Tickets)
                    .Where(x => x.TripId == tripId)
                    .FirstOrDefault();

                if(trip == null)
                {
                    throw new InvalidOperationException("No such trip.");
                }

                if(trip.Status.ToString().ToLower() == newStatus.ToLower())
                {
                    throw new InvalidOperationException("The new status must be different from the old one!");
                }

                string currentStatus = trip.Status.ToString();

                switch (newStatus)
                {
                    case "departed":
                        trip.Status = TripStatus.Departed;
                        break;
                    case "arrived":
                        trip.Status = TripStatus.Arrived;
                        break;
                    case "delayed":
                        trip.Status = TripStatus.Delayed;
                        break;
                    case "cancelled":
                        trip.Status = TripStatus.Cancelled;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();

                string outputStatus = trip.Status.ToString();

                if(newStatus == "arrived")
                {
                    var arrivedTrip = new ArrivedTrip()
                    {
                        ActualArriveTime = trip.ArrivalTime.AddMinutes(25),
                        ArriveDestinationBusStationId = trip.DestinationBusStationId,
                        ArriveOriginBusStationId = trip.OriginBusStationId,
                        PassengersCount = trip.Tickets.Count()
                    };
                    db.ArrivedTrips.Add(arrivedTrip);
                    db.SaveChanges();

                    StringBuilder sb = new StringBuilder();

                    string actualTime = arrivedTrip.ActualArriveTime.ToString(@"yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

                    sb.AppendLine($"Trip from {trip.OriginBusStation.Town.Name} to {trip.DestinationBusStation.Town.Name} on {trip.DepartureTime}");
                    sb.AppendLine($"Status changed from {currentStatus} to {outputStatus}");
                    sb.AppendLine($"On {actualTime} - {arrivedTrip.PassengersCount} passengers arrived at {trip.DestinationBusStation.Town.Name} from {trip.OriginBusStation.Town.Name}");
                    result = sb.ToString().Trim();

                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"Trip from {trip.OriginBusStation.Town.Name} to {trip.DestinationBusStation.Town.Name} on {trip.DepartureTime}");
                    sb.AppendLine($"Status changed from {currentStatus} to {outputStatus}");
                    result = sb.ToString().Trim();
                }
                
            }

            return result;
        }
    }
}
