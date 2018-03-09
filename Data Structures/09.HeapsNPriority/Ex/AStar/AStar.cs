using System;
using System.Collections.Generic;

public class AStar
{
    public AStar(char[,] map)
    {
        throw new NotImplementedException();
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        throw new NotImplementedException();
    }
}

