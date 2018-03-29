using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private Stack<T> items;

    public CustomStack()
    {
        this.items = new Stack<T>();
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            this.items.Push(element);
        }
    }

    public void Pop()
    {
        if(this.items.Count < 1)
        {
            throw new InvalidOperationException("No elements");
        }
        T item = this.items.Pop();        
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
