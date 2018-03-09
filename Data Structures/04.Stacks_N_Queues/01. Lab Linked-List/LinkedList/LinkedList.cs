using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node<T>
    {
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
    public int Count { get; private set; }

    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }

    public void AddFirst(T item)
    {
        Node<T> newHead = new Node<T>(item);
        // TODO
        if(this.Count == 0)
        {
            this.Head = this.Tail = newHead;
        }
        else
        {
            newHead.Next = this.Head;
            this.Head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        // TODO
        Node<T> newTail = new Node<T>(item);
        // TODO
        if (this.Count == 0)
        {
            this.Head = this.Tail = newTail;
        }
        else
        {
            this.Tail.Next = newTail;
            this.Tail = newTail;            
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        // TODO: Throw exception if the list is empty
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.Head.Value;

        this.Head = this.Head.Next;

        this.Count--;

        return element;
    }

    public T RemoveLast()
    {
        // TODO: Throw exception if the list is empty
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.Tail.Value;
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            var currHead = this.Head;

            while (currHead != null)
            {
                if (currHead.Next == this.Tail)
                {
                    currHead.Next = null;
                    this.Tail = currHead;
                    break;
                }
                currHead = currHead.Next;
            }
        }
        this.Count--;

        return element;
    }

    private Node<T> GetSecondToLast()
    {
        var currHead = this.Head;
        Node<T> secondToLast = null;

        while (currHead != null)
        {
            if (currHead.Next == this.Tail)
            {
                secondToLast = currHead;
            }
            currHead = currHead.Next;
        }
        return secondToLast;
    }

    public IEnumerator<T> GetEnumerator()
    {
        // TODO
        var currHead = this.Head;
        while (currHead != null)
        {
            yield return currHead.Value;
            currHead = currHead.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // TODO
        return this.GetEnumerator();
    }
}
