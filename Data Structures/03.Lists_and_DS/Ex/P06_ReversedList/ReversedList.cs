using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ReversedList<T> : IEnumerable<T>
{
    private const int Initial_Capacity = 2;
    private T[] items;

    private T[] reversed => this.items.Reverse().ToArray();
    public int Count { get; private set; }

    public int Capacity => this.items.Length;

    public ReversedList()
    {
        this.items = new T[Initial_Capacity];
    }

    public T this[int index]
    {
        get
        {
            if(index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int diff = this.Count - 1 - index;
            return this.items[diff];
        }
        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int diff = this.Count - 1 - index;
            this.items[diff] = value;
        }
    }

    public void Add(T item)
    {
        if(this.Count == this.items.Length)
        {
            this.Grow();
        }
        this.items[Count++] = item;
    }

    private void Grow()
    {
        int newCapacity = this.items.Length * 2;

        T[] copyArr = new T[newCapacity];
        this.Copy(this.items, copyArr);

        this.items = copyArr;
    }

    public T RemoveAt(int index)
    {
        if(index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        int diff = this.Count - index - 1;

        T element = this.items[index];

        this.items[index] = default(T);
        Shift(diff);
        this.Count--;

        if(this.Count <= this.items.Length / 4)
        {
            this.Shrink();
        }

        return element;
    }

    private void Shrink()
    {
        int newCapacity = this.items.Length / 2;

        T[] copyArr = new T[newCapacity];

        this.Copy(this.items, copyArr);
        this.items = copyArr;
    }

    private void Copy(T[] items, T[] copyArr)
    {
        for (int i = 0; i < this.Count; i++)
        {
            copyArr[i] = items[i];
        }
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.items[i] = this.items[i + 1];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}