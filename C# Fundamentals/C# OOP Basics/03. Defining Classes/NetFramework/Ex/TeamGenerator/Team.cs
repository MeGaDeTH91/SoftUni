using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string teamName;
    private List<Player> players;
    private double rating => this.GetMeTheRating();

    public void AddPlayer(Player playerToAdd)
    {
        this.Players.Add(playerToAdd);
    }
    public double Rating
    {
        get
        {
            return this.rating;
        }
    }

    private double GetMeTheRating()
    {
        double rating = this.Players.Sum(x => x.Average);

        return rating;
    }
    public void RemoveMeThePlayer(Player player)
    {
        this.Players.Remove(player);
    }
    public Player GetMeThePlayer(string seekPlayer)
    {
        return this.Players.FirstOrDefault(x => x.PlayerName == seekPlayer);
    }

    public Team(string name, List<Player> players)
    {
        this.TeamName = name;
        this.players = new List<Player>(players);
    }
    public Team(string name)
    {
        this.TeamName = name;
        this.players = new List<Player>();
    }

    public string TeamName
    {
        get
        {
            return this.teamName;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.teamName = value;
        }
    }
    private List<Player> Players
    {
        get
        {
            return this.players;
        }
        set
        {
            this.players = value;
        }
    }
}
