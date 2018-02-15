using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusTicketSystem.Models
{
    public class BusStation
    {
        public int BusStationId { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        [InverseProperty("OriginBusStation")]
        public ICollection<Trip> OriginTrips { get; set; } = new List<Trip>();

        [InverseProperty("DestinationBusStation")]
        public ICollection<Trip> DestinationTrips { get; set; } = new List<Trip>();

        [InverseProperty("ArriveOriginBusStation")]
        public ICollection<ArrivedTrip> ArrivedOriginTrips { get; set; } = new List<ArrivedTrip>();

        [InverseProperty("ArriveDestinationBusStation")]
        public ICollection<ArrivedTrip> ArrivedDestinationTrips { get; set; } = new List<ArrivedTrip>();
    }
}
