using System;
using System.Collections.Generic;
using Classes;
using Interfaces;
using Wintellect.PowerCollections;

public class PitFortressCollection : IPitFortress
{
        

    public PitFortressCollection()
    { 
    }

    public int PlayersCount { get; private set; }

    public int MinionsCount { get; private set; }

    public int MinesCount { get; private set; }

    public void AddPlayer(string name, int mineRadius)
    {
        throw new NotImplementedException();
    }

    public void AddMinion(int xCoordinate)
    {
        throw new NotImplementedException();
    }

    public void SetMine(string playerName, int xCoordinate, int delay, int damage)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Minion> ReportMinions()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> Top3PlayersByScore()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> Min3PlayersByScore()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Mine> GetMines()
    {
        throw new NotImplementedException();
    }

    public void PlayTurn()
    {
        throw new NotImplementedException();
    }
}
