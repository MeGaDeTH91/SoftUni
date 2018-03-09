using System;

public class ArrayList<T>
{
    
    private const int Initial_Capacity = 2;
    public int Count { get; set; }

    T[] items;

    public ArrayList()
    {
        this.items = new T[Initial_Capacity];
    }

    public T this[int index]
    {
        get
        {
            if(index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.items[index];
        }

        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        if(this.items.Length == this.Count)
        {
            this.Grow();
        }
        this.items[this.Count++] = item;
    }

    private void Grow()
    {
        int newCapacity = this.items.Length * 2;
        T[] copyArr = new T[newCapacity];

        this.Copy(this.items, copyArr);

        this.items = copyArr;
    }

    private void Copy(T[] items, T[] copyArr)
    {
        for (int index = 0; index < this.Count; index++)
        {
            copyArr[index] = items[index];
        }
    }

    public T RemoveAt(int index)
    {
        if(index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.items[index];
        this.items[index] = default(T);
        this.Shift(index);
        this.Count--;

        if(this.Count <= this.items.Length / 4)
        {
            this.Shrink();
        }

        return element;
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.items[i] = this.items[i + 1];
        }
    }

    private void Shrink()
    {
        int newCapacity = this.items.Length / 2;
        T[] copyArr = new T[newCapacity];

        Copy(this.items, copyArr);

        this.items = copyArr;
    }
}
