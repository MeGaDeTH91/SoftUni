using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T> where T : IComparable<T>
{
    private T Left;
    private T Right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHeavier()
    {
        if(this.Left.CompareTo(this.Right) > 0)
        {
            return this.Left;
        }
        else if(this.Left.CompareTo(this.Right) < 0)
        {
            return this.Right;
        }
        return default(T);
    }
}
