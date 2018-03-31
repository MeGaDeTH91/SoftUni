using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    HashSet<Invader> invaders;

    private int energy;

    public Computer(int energy)
    {
        this.Energy = energy >= 0? energy : throw new ArgumentException();
        this.invaders = new HashSet<Invader>();
    }

    public int Energy
    {
        get
        {
            return this.energy;
        }
        private set
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
        foreach (var invader in this.invaders)
        {
            invader.Distance-=turns;

            if(invader.Distance <= 0)
            {
                this.Energy -= invader.Damage;
            }
        }
        this.invaders.RemoveWhere(x => x.Distance <= 0);
    }

    public void AddInvader(Invader invader)
    {
        this.invaders.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        foreach (var invader in this.invaders.OrderBy(x => x).Take(count))
        {
            this.invaders.Remove(invader);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.invaders.RemoveWhere(x => x.Distance <= radius);
    }

    public IEnumerable<Invader> Invaders()
    {
        foreach (var invader in this.invaders)
        {
            yield return invader;
        }
    }
}
