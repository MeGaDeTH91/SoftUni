namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}
