using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamBuilder.Models
{
    public class User
    {
        public int UserId { get; set; }

        [MinLength(3)]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int? Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();

        public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();

        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public ICollection<Team> CreatedTeams { get; set; } = new List<Team>();  
    }
}
