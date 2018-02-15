using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<EventTeam> ParticipatingEventTeams { get; set; } = new List<EventTeam>();
    }
}
