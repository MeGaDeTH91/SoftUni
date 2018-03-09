using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> collectionByOrderOfInsertion = new LinkedList<T>();
    private OrderedBag<LinkedListNode<T>> SortedbyOrder = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
    private OrderedBag<LinkedListNode<T>> SortedbyOrderReversed = new OrderedBag<LinkedListNode<T>>((x, y) => y.Value.CompareTo(x.Value));

    public int Count => this.SortedbyOrder.Count;

    public void Add(T element)
    {
        var node = new LinkedListNode<T>(element);
        this.SortedbyOrder.Add(node);
        this.SortedbyOrderReversed.Add(node);
        this.collectionByOrderOfInsertion.AddLast(node);
    }

    public void Clear()
    {
        this.SortedbyOrder.Clear();
        this.SortedbyOrderReversed.Clear();
        this.collectionByOrderOfInsertion.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        ValidateCount(count);

        var current = this.collectionByOrderOfInsertion.First;
        while (count > 0)
        {
            yield return current.Value;
            current = current.Next;
            count--;
        }
    }

    public IEnumerable<T> Last(int count)
    {
        ValidateCount(count);

        var current = this.collectionByOrderOfInsertion.Last;
        while (count > 0)
        {
            yield return current.Value;
            current = current.Previous;
            count--;
        }
    }

    public IEnumerable<T> Max(int count)
    {
        ValidateCount(count);

        foreach (var element in this.SortedbyOrderReversed)
        {
            if(count <= 0)
            {
                break;
            }
            yield return element.Value;
            count--;
        }
    }

    public IEnumerable<T> Min(int count)
    {
        ValidateCount(count);

        foreach (var element in this.SortedbyOrder)
        {
            if (count <= 0)
            {
                break;
            }
            yield return element.Value;
            count--;
        }
    }

    public int RemoveAll(T element)
    {
        var node = new LinkedListNode<T>(element);
        var range = SortedbyOrder.Range(node, true, node, true);

        foreach (var item in range)
        {
            collectionByOrderOfInsertion.Remove(item);
        }

        var count = SortedbyOrder.RemoveAllCopies(node);
        SortedbyOrderReversed.RemoveAllCopies(node);

        return count;
    }
    private void ValidateCount(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
