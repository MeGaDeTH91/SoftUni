using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public decimal Price { get; set; }

        public string Seat { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
