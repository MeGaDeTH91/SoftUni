namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Train
    {
        public int Id { get; set; }

        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new List<TrainSeat>();

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
