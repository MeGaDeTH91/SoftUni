namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using Newtonsoft.Json;
    using Stations.Models;
    using Stations.DataProcessor.Dto;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using Stations.DataProcessor.Dto.Ticket;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
            var deserialisedStations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var stations = new List<Station>();

            foreach (var desStation in deserialisedStations)
            {                

                if (desStation.Town == null)
                {
                    desStation.Town = desStation.Name;
                }

                bool inputIsValid = !String.IsNullOrWhiteSpace(desStation.Name) &&
                    desStation.Name.Length <= 50 &&
                    desStation.Town.Length <= 50;

                if (!inputIsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool stationExistsLocal = stations.Any(x => x.Name == desStation.Name);
                bool stationExistsDb = context.Stations.Any(x => x.Name == desStation.Name);

                if(stationExistsLocal || stationExistsDb)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = new Station()
                {
                    Name = desStation.Name,
                    Town = desStation.Town
                };
                stations.Add(station);

                sb.AppendLine(String.Format(SuccessMessage, desStation.Name));
            }
            context.Stations.AddRange(stations);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
            var seatedClassesDeserialize = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var seatedClasses = new List<SeatingClass>();

            foreach (var seatClassDto in seatedClassesDeserialize)
            {
                if(string.IsNullOrWhiteSpace(seatClassDto.Name) ||
                    string.IsNullOrWhiteSpace(seatClassDto.Abbreviation) ||
                    seatClassDto.Name.Length > 30 || seatClassDto.Abbreviation.Length != 2)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(seatedClasses.Any(x => x.Name == seatClassDto.Name) ||
                    seatedClasses.Any(x => x.Abbreviation == seatClassDto.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                SeatingClass seatingClass = new SeatingClass()
                {
                    Name = seatClassDto.Name,
                    Abbreviation = seatClassDto.Abbreviation
                };

                seatedClasses.Add(seatingClass);
                sb.AppendLine(String.Format(SuccessMessage, seatClassDto.Name));
            }
            context.SeatingClasses.AddRange(seatedClasses);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
            var deserializedTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            StringBuilder sb = new StringBuilder();

            var trains = new List<Train>();

            foreach (var trainDto in deserializedTrains)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                bool trainExists = trains.Any(x => x.TrainNumber == trainDto.TrainNumber);

                if (trainExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatsAreValid = trainDto.Seats.All(IsValid);

                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClassesAreValid = trainDto.Seats
                    .All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));

                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainType = Enum.Parse<TrainType>(trainDto.Type);

                var trainSeats = trainDto.Seats.Select(s => new TrainSeat
                {
                    SeatingClass =
                            context.SeatingClasses.SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                    .ToArray();

                var train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = trainType,
                    TrainSeats = trainSeats
                };

                trains.Add(train);
                sb.AppendLine(String.Format(SuccessMessage, trainDto.TrainNumber));

            }
            context.Trains.AddRange(trains);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
            var deserializedTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString,
                new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            StringBuilder sb = new StringBuilder();

            var validTrips = new List<Trip>();

            foreach (var tripDto in deserializedTrips)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime departureTime;
                bool isValidDepTime = DateTime.TryParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out departureTime);

                DateTime arrivalTime;
                bool isValidArriveTime = DateTime.TryParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrivalTime);

                if (!isValidArriveTime || !isValidDepTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var originStation = context.Stations
                    .FirstOrDefault(x => x.Name == tripDto.OriginStation);

                var destinationStation = context.Stations
                    .FirstOrDefault(x => x.Name == tripDto.DestinationStation);

                var train = context.Trains
                    .FirstOrDefault(x => x.TrainNumber == tripDto.Train);

                var bothStationsExist = originStation != null && destinationStation != null;

                if(!bothStationsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(train == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(arrivalTime < departureTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TimeSpan timeDifference;
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                var tripStatus = Enum.Parse<TripStatus>(tripDto.Status);

                var trip = new Trip()
                {
                    OriginStationId = originStation.Id,
                    DestinationStationId = destinationStation.Id,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    TrainId = train.Id,
                    Status = tripStatus,
                    TimeDifference = timeDifference
                };
                validTrips.Add(trip);
                sb.AppendLine($"Trip from {originStation.Name} to {destinationStation.Name} imported.");
            }
            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));
            var deserializedCards = (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));            

            StringBuilder sb = new StringBuilder();

            var validCards = new List<CustomerCard>();

            foreach (var card in deserializedCards)
            {
                string name = card.Name;
                int age = card.Age;
               
                //CardType cardType = Enum.Parse<CardType>(card.CardType);
                CardType cardType = Enum.TryParse<CardType>(card.CardType, out var card1) ? card1 : CardType.Normal;

                bool nameIsValid = name.Length > 0 && name.Length <= 128;
                bool ageIsValid = age >= 0 && age <= 120;

                if(!nameIsValid || !ageIsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                var customerCard = new CustomerCard()
                {
                    Name = name,
                    Age = age,
                    Type = cardType
                };
                validCards.Add(customerCard);
                sb.AppendLine(String.Format(SuccessMessage, card.Name));

            }
            context.Cards.AddRange(validCards);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            StringBuilder sb = new StringBuilder();

            var validTickets = new List<Ticket>();

            foreach (var ticketDto in deserializedTickets)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime =
                    DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                                              t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                                              t.DepartureTime == departureTime);
                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
                var quantity = int.Parse(ticketDto.Seat.Substring(2));

                var seatExists = trip.Train.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && quantity <= s.Quantity);
                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seat = ticketDto.Seat;

                var ticket = new Ticket
                {
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticketDto.Price,
                    SeatingPlace = seat
                };

                validTickets.Add(ticket);
                sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.",
                    trip.OriginStation.Name,
                    trip.DestinationStation.Name,
                    trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }
            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
	}
}