namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using Newtonsoft.Json;
    using System.Linq;
    using Stations.Models;
    using System.Globalization;
    using Stations.DataProcessor.Dto.Export;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml;
    using System.Text;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            DateTime parsedDepDate = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trains = context.Trains
                .Where(x => x.Trips.Any(y => y.Status == TripStatus.Delayed &&
                y.DepartureTime <= parsedDepDate))
                .Select(t => new
                {
                    t.TrainNumber,
                    DelayedTimes = t.Trips.Where(x => x.Status == TripStatus.Delayed &&
                x.DepartureTime <= parsedDepDate).ToArray()
                })
                .Select(x => new ExportTrainDto
                {
                    TrainNumber = x.TrainNumber,
                    DelayedTimes = x.DelayedTimes.Length,
                    MaxDelayedTime = x.DelayedTimes.Max(y => y.TimeDifference).ToString()
                })
                .OrderByDescending(x => x.DelayedTimes)
                .ThenByDescending(x => x.MaxDelayedTime)
                .ThenBy(x => x.TrainNumber);



            var jsonString = JsonConvert.SerializeObject(trains, Formatting.Indented);

            return jsonString;
        }

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            CardType type = Enum.Parse<CardType>(cardType);

            var cards = context.Cards
                .Where(c => c.Type == type && c.BoughtTickets.Any())
                .Select(c => new ExportCardDto
                {
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    Tickets = c.BoughtTickets.Select(t => new ExportTicketDto
                    {
                        OriginStation = t.Trip.OriginStation.Name,
                        DestinationStation = t.Trip.DestinationStation.Name,
                        DepartureTime = t.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                    }).ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ExportCardDto[]), new XmlRootAttribute("Cards"));
            serializer.Serialize(new StringWriter(sb), cards, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
	}
}