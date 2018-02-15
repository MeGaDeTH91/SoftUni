using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Team
{
    private string name;
    private int playersNum;
    private decimal rating;
    private List<Player> players = new List<Player>();

    public void PlayerRemoval(string teamName, string playerName)
    {
        Player removeP = Players.First(x => x.Name == playerName);
        Players.Remove(removeP);
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int PlayersNum
    {
        get
        {
            return this.playersNum;
        }
        set
        {
            this.playersNum = this.Players.Count;
        }
    }

    public decimal Rating
    {
        get
        {
            return this.rating;
        }
        set
        {
            this.rating = value;
        }
    }

    public List<Player> Players
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
    public decimal CalculateRating(string name)
    {
        if (Players.Count > 0)
        {
            return Players.Average(x => x.AvgStats);
        }
        else return 0;
    }
}