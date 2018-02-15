using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketSystem.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string Content { get; set; }

        public double Grade { get; set; } = 0;

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
