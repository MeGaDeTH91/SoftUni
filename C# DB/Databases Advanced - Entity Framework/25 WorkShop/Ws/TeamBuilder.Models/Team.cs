using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamBuilder.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }

        [MinLength(3), MaxLength(3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public ICollection<EventTeam> EventTeams { get; set; } = new List<EventTeam>();
    }
}
