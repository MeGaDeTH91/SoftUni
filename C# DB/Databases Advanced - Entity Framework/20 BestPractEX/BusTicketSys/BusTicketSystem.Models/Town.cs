using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusTicketSystem.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        [InverseProperty("HomeTown")]
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public ICollection<BusStation> BusStations { get; set; } = new List<BusStation>();
    }
}
