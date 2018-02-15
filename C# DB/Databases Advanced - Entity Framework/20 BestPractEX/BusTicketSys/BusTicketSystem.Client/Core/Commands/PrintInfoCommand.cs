namespace BusTicketSystem.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using BusTicketSystem.Data;
    using BusTicketSystem.Models;
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public class PrintInfoCommand
    {
        public static string Execute(string[] data)
        {
            int stationId = int.Parse(data[1]);
            string result = string.Empty;

            StringBuilder sb = new StringBuilder();

            using(var context = new BusTicketContext())
            {
                var station = context.BusStations
                    .Include(x => x.Town)
                    .Where(x => x.BusStationId == stationId).FirstOrDefault();

                if(station == null)
                {
                    throw new InvalidOperationException("Non-Existing Bus Station!");
                }

                var arrivalTrips = context.Trips
                    .Include(x => x.OriginBusStation)
                    .Include(x => x.DestinationBusStation)
                    .Where(x => x.DestinationBusStationId == stationId).ToList();

                var originTrips = context.Trips
                    .Include(x => x.OriginBusStation)
                    .Include(x => x.DestinationBusStation)
                    .Where(x => x.OriginBusStationId == stationId).ToList();

                sb.AppendLine($"{station.Name}, {station.Town.Name}");
                sb.AppendLine($"Arrivals:");

                if (arrivalTrips.Count > 0)
                {                    
                    foreach (var arrive in arrivalTrips)
                    {
                        sb.AppendLine($"From {arrive.OriginBusStation.Name} | Arrive at: {arrive.ArrivalTime.ToString("HH:mm", CultureInfo.InvariantCulture)} | Status: {arrive.Status.ToString()}");
                    }
                }
                else
                {
                    sb.AppendLine("No current arrives.");
                }

                sb.AppendLine("Departures:");

                if (originTrips.Count > 0)
                {
                    foreach (var origin in originTrips)
                    {
                        sb.AppendLine($"To {origin.DestinationBusStation.Name} | Depart at: {origin.ArrivalTime.ToString("HH:mm", CultureInfo.InvariantCulture)} | Status: {origin.Status.ToString()}");
                    }
                }
                else
                {
                    sb.AppendLine("No current departures.");
                }
                result = sb.ToString().Trim();
            }
            

            return result;
        }
    }
}
