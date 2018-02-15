namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomerCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; } = new List<Ticket>();
    }
}
