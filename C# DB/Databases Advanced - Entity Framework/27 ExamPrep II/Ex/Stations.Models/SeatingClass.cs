namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SeatingClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new List<TrainSeat>();
    }
}
