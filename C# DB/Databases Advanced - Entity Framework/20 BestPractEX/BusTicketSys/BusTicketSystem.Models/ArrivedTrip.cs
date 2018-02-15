using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketSystem.Models
{
    public class ArrivedTrip
    {
        public int ArrivedTripId { get; set; }

        public DateTime ActualArriveTime { get; set; }

        public int ArriveOriginBusStationId { get; set; }
        public BusStation ArriveOriginBusStation { get; set; }

        public int ArriveDestinationBusStationId { get; set; }
        public BusStation ArriveDestinationBusStation { get; set; }

        public int PassengersCount { get; set; }
    }
}
