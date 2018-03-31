using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tree<T>
{
    public T Value { get; set; }
    public Tree<T> Parent { get; set; }
    public List<Tree<T>> Children { get; private set; }
    public int Deepness { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public void PrintTree(int indent = 0)
    {
        this.PrintTree(this, indent);
    }

    private void PrintTree(Tree<T> node, int indent)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine($"{new string(' ', indent)} {node.Value}");

        foreach (var child in node.Children)
        {
            child.PrintTree(indent + 2);
        }
    }

    public List<Tree<T>> GetLeafNodes()
    {
        var leafNodes = new List<Tree<T>>();

        this.GetLeafNodesRec(this, leafNodes);

        return leafNodes;
    }

    private void GetLeafNodesRec(Tree<T> node, List<Tree<T>> leafNodes)
    {
        if (node == null)
        {
            return;
        }
        if (node.Children.Count == 0)
        {
            leafNodes.Add(node);
        }

        foreach (var child in node.Children)
        {
            child.GetLeafNodesRec(child, leafNodes);
        }
    }

    public List<T> GetPath()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            result.Add(current.Value);
            
            if(current.Parent != null)
            {
                queue.Enqueue(current.Parent);
            }

        }

        result.Reverse();

        return result;
    }

    public List<Tree<T>> GetMiddleNodes()
    {
        var middleNodes = new List<Tree<T>>();

        this.GetMiddleNodesRec(this, middleNodes);

        return middleNodes;
    }

    public List<T> OrderDFS()
    {
        var result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        result.Add(tree.Value);

        foreach (var child in tree.Children)
        {
            this.DFS(child, result);
        }
    }

    private void GetMiddleNodesRec(Tree<T> node, List<Tree<T>> middleNodes)
    {
        if (node == null)
        {
            return;
        }
        if (node.Parent != null && node.Children.Count != 0)
        {
            middleNodes.Add(node);
        }

        foreach (var child in node.Children)
        {
            child.GetMiddleNodesRec(child, middleNodes);
        }
    }

    public List<Tree<T>> GetNodesDeepness(int deepness = 0)
    {
        var result = new List<Tree<T>>();

        this.GetNodesDeepnessRec(this, deepness, result);

        return result;
    }

    private void GetNodesDeepnessRec(Tree<T> node, int deepness, List<Tree<T>> result)
    {
        if (node == null)
        {
            return;
        }

        node.Deepness = deepness;

        result.Add(node);

        foreach (var child in node.Children)
        {
            child.GetNodesDeepnessRec(child, deepness + 1, result);
        }
    }
}
