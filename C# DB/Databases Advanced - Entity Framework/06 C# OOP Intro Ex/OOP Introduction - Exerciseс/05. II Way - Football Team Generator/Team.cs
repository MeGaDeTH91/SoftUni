using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Team
{
    private string name;
    private int playersNum;
    private int rating;
    private List<Player> players = new List<Player>();

    public Team()
    {

    }
    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    internal void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    internal void PlayerRemoval(string playerName)
    {
        if (!this.players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        this.players.Remove(this.players.First(p => p.Name == playerName));
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
    internal int Rating(string name)
    {
        if (Players.Count > 0)
        {
            return (int)Players.Average(x => x.AverageStats());
        }
        else return 0;
    }
}