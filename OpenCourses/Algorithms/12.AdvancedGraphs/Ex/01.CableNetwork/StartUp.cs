namespace _01.CableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    
    public class StartUp
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> spanningTree;
        private static int initialBudget = 0;
        private static int currentBudget = 0;

        public static void Main()
        {
            ReadInput();

            IncreaseNetwork();

            PrintResult();
        }

        private static void PrintResult()
        {
            var diff = initialBudget - currentBudget;

            Console.WriteLine($"Budget used: {diff}");
        }

        private static void ReadInput()
        {
            graph = new Dictionary<int, List<Edge>>();
            spanningTree = new HashSet<int>();

            initialBudget = int.Parse(Console.ReadLine().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            currentBudget = initialBudget;

            int nodeCount = int.Parse(Console.ReadLine().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]);

            int edgeCount = int.Parse(Console.ReadLine().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]);

            for (int i = 0; i < edgeCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int firstNode = int.Parse(tokens[0]);
                int secondNode = int.Parse(tokens[1]);
                int cost = int.Parse(tokens[2]);

                Edge edge = new Edge(firstNode, secondNode, cost);

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<Edge>();
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<Edge>();
                }
                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);

                if (tokens.Length > 3)
                {
                    spanningTree.Add(firstNode);
                    spanningTree.Add(secondNode);
                }
            }
        }

        public static void IncreaseNetwork()
        {
            var queue = new OrderedBag<Edge>();

            queue.AddMany(spanningTree.SelectMany(x => graph[x]));

            while (queue.Count > 0 && currentBudget > 0)
            {
                var minEdge = queue.GetFirst();
                queue.RemoveFirst();

                int firstNode = minEdge.StartNode;
                int secondNode = minEdge.EndNode;

                int nonTreeNode = -1;

                if(spanningTree.Contains(firstNode) &&
                   !spanningTree.Contains(secondNode) &&
                   currentBudget - minEdge.Cost >= 0)
                {
                    nonTreeNode = secondNode;

                    
                }
                else if (spanningTree.Contains(secondNode) &&
                   !spanningTree.Contains(firstNode) &&
                   currentBudget - minEdge.Cost >= 0)
                {
                    nonTreeNode = firstNode;
                }
                else if(nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);
                queue.AddMany(graph[nonTreeNode]);
                currentBudget -= minEdge.Cost;
            }
        }
    }
}
