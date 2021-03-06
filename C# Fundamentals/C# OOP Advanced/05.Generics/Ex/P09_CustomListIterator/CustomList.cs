﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> elements;

    public CustomList()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }
    public T Remove(int index)
    {
        T element = this.elements[index];

        this.elements.RemoveAt(index);

        return element;
    }
    public bool Contains(T element)
    {
        return this.elements.Any(x => x.Equals(element));
    }
    public void Swap(int index1, int index2)
    {
        T tempElement = this.elements[index1];
        this.elements[index1] = this.elements[index2];
        this.elements[index2] = tempElement;
    }
    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var currElement in this.elements)
        {
            if(currElement.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
    public T Max()
    {
        return this.elements.Max();
    }
    public T Min()
    {
        return this.elements.Min();
    }
    public void Sort()
    {
        this.elements.Sort();
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, this.elements);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var el in this.elements)
        {
            yield return el;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
