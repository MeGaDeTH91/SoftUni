using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> elements;

    private int index;

    public ListyIterator(params T[] elements)
    {
        this.elements = new List<T>(elements);
    }

    public void PrintAll()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(string.Join(" ", this.elements));
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.elements[this.index]);
    }
    
    public bool Move()
    {
        if(this.index + 1 < this.elements.Count)
        {
            this.index++;
            return true;
        }
        return false;
    }
    public bool HasNext()
    {
        if(this.index + 1> this.elements.Count - 1)
        {
            return false;
        }
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in this.elements)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
