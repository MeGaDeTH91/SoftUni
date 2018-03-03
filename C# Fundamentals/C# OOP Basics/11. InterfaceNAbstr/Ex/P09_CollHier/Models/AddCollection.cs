using System;
using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    public AddCollection()
    {
        this.Collection = new List<T>();
    }

    protected List<T> Collection { get; set; }

    public virtual int Add(T element)
    {
        this.Collection.Add(element);
        return this.Collection.Count - 1;
    }
}
