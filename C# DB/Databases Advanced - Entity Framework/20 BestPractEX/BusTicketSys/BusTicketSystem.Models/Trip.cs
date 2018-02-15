using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketSystem.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TripStatus Status { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public int OriginBusStationId { get; set; }
        public BusStation OriginBusStation { get; set; }

        public int DestinationBusStationId { get; set; }
        public BusStation DestinationBusStation { get; set; }

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }
    }
}
