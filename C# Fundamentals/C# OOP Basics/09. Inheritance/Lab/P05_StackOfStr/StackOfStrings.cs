using System;
using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        if(this.data.Count > 0)
        {
            string element = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return element;
        }
        else
        {
            return null;
        }
    }

    public string Peek()
    {
        if (this.data.Count > 0)
        {
            string element = this.data.Last();
            return element;
        }
        else
        {
            return null;
        }
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}
