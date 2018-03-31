using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Hierarchy<T> : IHierarchy<T>
{
    private Tree root;
    private Dictionary<T, Tree> nodes;

    public Hierarchy(T root)
    {
        this.root = new Tree(root);
        this.nodes = new Dictionary<T, Tree>
        {
            { root, this.root }
        };
    }

    public int Count => this.nodes.Count;

    public void Add(T element, T child)
    {
        if (!this.nodes.ContainsKey(element))
        {
            throw new ArgumentException("Parent not found");
        }
        
        if(this.nodes.ContainsKey(child))
        {
            throw new ArgumentException("Child already exists");
        }
        var parentNode = nodes[element];
        var childNode = new Tree(child)
        {
            Parent = parentNode
        };
        this.nodes[child] = childNode;
        parentNode.Children.Add(childNode);
    }

    public void Remove(T element)
    {
        if(this.root.Value.Equals(element))
        {
            throw new InvalidOperationException();
        }
        if (!this.nodes.ContainsKey(element))
        {
            throw new ArgumentException();
        }
        var parentNode = this.nodes[element].Parent;
        var removeNode = this.nodes[element];
        foreach (var child in removeNode.Children)
        {
            child.Parent = parentNode;
        }
        parentNode.Children.AddRange(removeNode.Children);
        
        parentNode.Children.Remove(removeNode);
        this.nodes.Remove(element);
    }

    public IEnumerable<T> GetChildren(T item)
    {
        if (!this.nodes.ContainsKey(item))
        {
            throw new ArgumentException();
        }
        var parentNode = this.nodes[item];

        return parentNode.Children.Select(x => x.Value);
    }

    public T GetParent(T item)
    {
        if (!this.nodes.ContainsKey(item))
        {
            throw new ArgumentException();
        }
        var childNode = this.nodes[item];
        T parent = default(T);
        if(childNode.Parent != null)
        {
            parent = childNode.Parent.Value;
        }
        return parent ;
    }

    public bool Contains(T value)
    {
        return this.nodes.ContainsKey(value);
    }

    public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
    {
        HashSet<T> tempColl = new HashSet<T>();

        foreach (var node in this.nodes)
        {
            if (other.nodes.ContainsKey(node.Key))
            {
                tempColl.Add(node.Key);
            }
        }
        return tempColl;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var result = new List<T>();
        var queue = new Queue<Tree>();
        queue.Enqueue(this.root);

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();
            result.Add(currNode.Value);
            foreach (var child in currNode.Children)
            {
                queue.Enqueue(child);
            }
        }

        if (result.Count > 0)
        {
            foreach (var item in result)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public class Tree
    {
        public Tree Parent { get; set; }
        public T Value { get; set; }
        public List<Tree> Children { get; set; }

        public Tree(T value, Tree parent = null)
        {
            this.Parent = parent;
            this.Value = value;
            this.Children = new List<Tree>();
        }
    }
}
