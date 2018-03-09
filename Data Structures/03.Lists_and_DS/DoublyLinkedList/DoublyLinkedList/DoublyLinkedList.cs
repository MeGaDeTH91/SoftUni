using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class ListNode<T>
    {
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }
        public T Value { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode<T> newHead = new ListNode<T>(element);
        if(this.Count == 0)
        {
            this.head = this.tail = newHead;
        }
        else
        {
            this.head.Previous = newHead;
            var oldHead = this.head;
            this.head = newHead;
            this.head.Next = oldHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newTail = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.head = this.tail = newTail;
        }
        else
        {
            this.tail.Next = newTail;
            var oldTail = this.tail;
            this.tail = newTail;
            this.tail.Previous = oldTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.head.Value;
        if(this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.head = this.head.Next;
            this.head.Previous = null;
        }

        this.Count--;

        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.tail.Value;
        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.tail = this.tail.Previous;
            this.tail.Next = null;
        }

        this.Count--;

        return element;
    }

    public void ForEach(Action<T> action)
    {
        var currHead = this.head;
        while (currHead != null)
        {
            action(currHead.Value);
            currHead = currHead.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currHead = this.head;
        while (currHead != null)
        {
            yield return currHead.Value;
            currHead = currHead.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        int counter = 0;

        T[] resultArr = new T[this.Count];

        var currHead = this.head;
        while (currHead != null)
        {
            resultArr[counter] = currHead.Value;
            currHead = currHead.Next;
            counter++;
        }
        return resultArr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
