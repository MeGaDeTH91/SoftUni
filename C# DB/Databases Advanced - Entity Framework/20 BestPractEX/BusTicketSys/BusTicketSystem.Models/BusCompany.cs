using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BusTicketSystem.Models
{
    public class BusCompany
    {
        public int BusCompanyId { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public double Rating { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
