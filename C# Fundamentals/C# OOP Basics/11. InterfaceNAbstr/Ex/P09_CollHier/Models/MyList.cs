using System;
using System.Collections.Generic;

public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    private int Used => this.Collection.Count;

    public MyList()
    {
        this.Collection = new List<T>();
    }

    public override T Remove()
    {
        if(this.Collection.Count > 0)
        {
            T element = this.Collection[0];
            this.Collection.RemoveAt(0);
            return element;
        }
        else
        {
            return default(T);
        }
    }

    public override int Add(T element)
    {
        this.Collection.Insert(0, element);
        return 0;
    }
}
