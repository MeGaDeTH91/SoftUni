using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    private BinarySearchTree(Node root)
    {
        this.Copy(root);
    }
    public BinarySearchTree()
    {

    }

    private void Copy(Node node)
    {
        if(node == null)
        {
            return;
        }
        this.Insert(node.Value);
        this.Copy(node.LeftNode);
        this.Copy(node.RightNode);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }

    public void Insert(T value)
    {
        Node addNode = new Node(value);

        if(this.root == null)
        {
            this.root = addNode;
            return;
        }
        Node current = this.root;
        Node parent = null;

        while (current != null)
        {
            parent = current;
            if (value.CompareTo(current.Value) < 0)
            {
                current = current.LeftNode;
            }
            else if(value.CompareTo(current.Value) > 0)
            {
                current = current.RightNode;
            }
            else
            {
                return;
            }
        }
        if(parent != null)
        {
            if(parent.Value.CompareTo(value) < 0)
            {
                parent.RightNode = new Node(value);
            }
            else
            {
                parent.LeftNode = new Node(value);
            }
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;
        while (current != null)
        {
            if(current.Value.CompareTo(value) < 0)
            {
                current = current.RightNode;
            }
            else if(current.Value.CompareTo(value) > 0)
            {
                current = current.LeftNode;
            }
            else
            {
                break;
            }
        }

        return current != null;
    }

    public void DeleteMin()
    {
        if(this.root == null)
        {
            return;
        }
        Node current = this.root;
        Node parent = null;

        while (current.LeftNode != null)
        {
            parent = current;
            current = parent.LeftNode;
        }
             //|
        //ЗАЩО v
        if (parent == null)
        {
            this.root = this.root.RightNode;
        }
        else
        {
            parent.LeftNode = current.RightNode;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        var current = this.root;
        if(current == null)
        {
            return null;
        }

        while (current != null)
        {
            if(item.CompareTo(current.Value) < 0)
            {
                current = current.LeftNode;
            }
            else if(item.CompareTo(current.Value) > 0)
            {
                current = current.RightNode;
            }
            else
            {
                break;
            }
        }
        return new BinarySearchTree<T>(current);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if(node == null)
        {
            return;
        }
        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInUpperRange = endRange.CompareTo(node.Value);

        if(nodeInLowerRange < 0)
        {
            this.Range(node.LeftNode, queue, startRange, endRange);
        }
        if(nodeInLowerRange <= 0 && nodeInUpperRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if(nodeInUpperRange > 0)
        {
            this.Range(node.RightNode, queue, startRange, endRange);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node root, Action<T> action)
    {
        if(root == null)
        {
            return;
        }
        this.EachInOrder(root.LeftNode, action);
        action(root.Value);
        this.EachInOrder(root.RightNode, action);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        
    }
}
