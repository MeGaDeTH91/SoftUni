using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stations.Models
{
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        [InverseProperty("DestinationStation")]
        public ICollection<Trip> TripsTo { get; set; } = new List<Trip>();
                
        [InverseProperty("OriginStation")]
        public ICollection<Trip> TripsFrom { get; set; } = new List<Trip>();
    }
}
