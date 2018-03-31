using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main(string[] args)
    {
        ReadTree();
        Tree<int> root = GetRootNode();

        //1. Root Node
        //Console.WriteLine($"Root node: {root.Value}");

        //2. Print Tree
        //root.PrintTree();

        //3. LeafNodes
        //List<Tree<int>> leafNodes = root.GetLeafNodes();
        //PrintLeafNodes(leafNodes);

        //4. MiddleNodes
        //List<Tree<int>> middleNodes = root.GetMiddleNodes();
        //PrintMiddleNodes(middleNodes);

        //5. Deepest Node
        //List<Tree<int>> nodesDeepness = root.GetNodesDeepness()
        //    .OrderByDescending(x => x.Deepness)
        //    .ToList();                          
        //PrintDeepestNode(nodesDeepness);

        //6.Longest Path
        //List<Tree<int>> nodesDeepness = root.GetNodesDeepness()
        //    .OrderByDescending(x => x.Deepness)
        //    .ToList();
        //Tree<int> deepestNode = nodesDeepness[0];
        //List<int> longestPath = deepestNode.GetPath();
        //Console.WriteLine($"Longest path: {string.Join(" ", longestPath)}");

        //7. AllPathsWithGivenSum
        //int sum = int.Parse(Console.ReadLine());
        //List<Tree<int>> leafNodes = root.GetLeafNodes();

        //PrintPathsWithThisSum(leafNodes, sum);

        //8. AllPathsWithGivenSum
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {sum}:");
        PrintSubTreesOfSum(root, sum);
    }

    private static int PrintSubTreesOfSum(Tree<int> root, int sum)
    {
        int currentSum = root.Value;
        int subtreeSum = 0;

        foreach (var child in root.Children)
        {
            currentSum += child.Value;
            subtreeSum += PrintSubTreesOfSum(child, sum);
        }

        if(currentSum == sum || sum == subtreeSum)
        {
            var toPrint = root.OrderDFS();
            Console.WriteLine(string.Join(" ", toPrint));
        }

        return currentSum;
    }

    private static void PrintPathsWithThisSum(List<Tree<int>> leafNodes, int sum)
    {
        Console.WriteLine($"Paths of sum {sum}:");

        foreach (var leaf in leafNodes)
        {
            List<int> nodePath = leaf.GetPath();

            if(nodePath.Sum() == sum)
            {
                Console.WriteLine(string.Join(" ", nodePath));
            }
        }
    }

    private static void PrintDeepestNode(List<Tree<int>> nodesDeepness)
    {
        Console.WriteLine($"Deepest node: {nodesDeepness[0].Value}");
    }

    private static void PrintMiddleNodes(List<Tree<int>> middleNodes)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var node in middleNodes.OrderBy(x => x.Value))
        {
            sb.Append($"{node.Value} ");
        }

        Console.WriteLine($"Middle nodes: {sb.ToString().TrimEnd()}");
    }

    public static void PrintLeafNodes(List<Tree<int>> leafNodes)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var node in leafNodes.OrderBy(x => x.Value))
        {
            sb.Append($"{node.Value} ");
        }

        Console.WriteLine($"Leaf nodes: {sb.ToString().TrimEnd()}");
    }

    public static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());

        for (int i = 1; i < nodeCount; i++)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int parent = input[0];
            int child = input[1];

            AddEdge(parent, child);

        }
    }

    public static Tree<int> GetRootNode()
    {
        return nodeByValue.Values
            .FirstOrDefault(x => x.Parent == null);
    }

    public static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    public static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue.Add(value, new Tree<int>(value));
        }
        return nodeByValue[value];
    }

    
}

