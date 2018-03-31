using System;
using System.Collections.Generic;
using System.Linq;

public class Computer : IComputer
{
    public HashSet<Invader> Record { get; set; }
    private int energy;

    public Computer()
    {
        this.Record = new HashSet<Invader>();
    }
    public Computer(int energy)
    {
        if(energy < 0)
        {
            throw new ArgumentException();
        }
        this.Record = new HashSet<Invader>();
        this.Energy = energy;
    }

    public int Energy
    {
        get
        {
            return this.energy > 0 ? this.energy : 0;
        }
        set
        {
            if(value < 0)
            {
                this.energy = 0;
            }
            else
            {
                this.energy = value;
            }
            
        }
    }

    public void Skip(int turns)
    {
        foreach (var invader in this.Record)
        {
            invader.Distance -= turns;
        }
        foreach (var invader in this.Record)
        {
            if(invader.Distance <= 0)
            {
                this.Energy -= invader.Damage;
            }
        }
        this.Record.RemoveWhere(x => x.Distance <= 0);
    }

    public void AddInvader(Invader invader)
    {
        this.Record.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        foreach (var invader in this.Record.OrderBy(x => x).Take(count))
        {
            this.Record.Remove(invader);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.Record.RemoveWhere(x => x.Distance <= radius);
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.Record;
    }
}
