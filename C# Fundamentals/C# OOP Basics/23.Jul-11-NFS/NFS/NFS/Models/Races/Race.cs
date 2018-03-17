using System;
using System.Collections.Generic;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;
    public int ParticipantCount => this.participants.Count;
    private int goldTime;
    private int laps;

    public int Laps
    {
        get { return this.laps; }
        protected set { this.laps = value; }
    }

    public int GoldTime
    {
        get { return this.goldTime; }
        protected set { this.goldTime = value; }
    }

    public void AddParticipant(Car car)
    {
        if (!this.Participants.Contains(car))
        {
            this.participants.Add(car);
        }        
    }

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new List<Car>();
    }

    public int Length
    {
        get { return this.length; }
        protected set { this.length = value; }
    }

    public string Route
    {
        get { return this.route; }
        protected set { this.route = value; }
    }
    
    public int PrizePool
    {
        get { return this.prizePool; }
        protected set { this.prizePool = value; }
    }
    public List<Car> Participants
    {
        get
        {
            return this.participants;
        }
        protected set
        {
            this.participants = value;
        }
    }
}
