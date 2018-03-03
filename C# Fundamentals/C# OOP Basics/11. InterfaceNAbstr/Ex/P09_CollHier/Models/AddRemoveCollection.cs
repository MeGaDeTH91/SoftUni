using System;
using System.Collections.Generic;

public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    public AddRemoveCollection()
    {
        this.Collection = new List<T>();
    }

    public virtual T Remove()
    {
        if(this.Collection.Count > 0)
        {
            T element = this.Collection[this.Collection.Count - 1];
            this.Collection.RemoveAt(this.Collection.Count - 1);
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
