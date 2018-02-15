namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Color
    {
        public int ColorId { get; set; }

        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams { get; set; } = new List<Team>();

        [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set; } = new List<Team>();
    }
}
