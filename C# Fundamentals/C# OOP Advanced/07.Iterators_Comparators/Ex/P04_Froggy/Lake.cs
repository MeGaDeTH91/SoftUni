using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake : IEnumerable<int>
{
    List<int> stones;

    public Lake(params int[] addStones)
    {
        this.stones = new List<int>(addStones);
    }

    public void Jump()
    {
        List<int> evenPositions = new List<int>();
        Stack<int> reversedOnes = new Stack<int>();
        for (int i = 0; i < this.stones.Count; i++)
        {
            if(i % 2 == 0)
            {
                evenPositions.Add(this.stones[i]);
            }
            else
            {
                reversedOnes.Push(this.stones[i]);
            }
        }
        evenPositions.AddRange(reversedOnes);
        Console.WriteLine(string.Join(", ", evenPositions));
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var stone in this.stones)
        {
            yield return stone;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
