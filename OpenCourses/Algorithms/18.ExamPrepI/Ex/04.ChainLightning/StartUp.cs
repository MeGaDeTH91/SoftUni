namespace _04.ChainLightning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        private static Dictionary<int, List<Edge>> graph;
        private static Dictionary<int, long> damages;
        private static List<string> lightnings;
        private static int lightningCount = 0;

        public static void Main()
        {
            ReadInput();

            DoSomeDamage();

            PrintResult();
        }

        private static void PrintResult()
        {
            long maxResult = damages.Values.Max();

            Console.WriteLine(maxResult);
        }

        private static void DoSomeDamage()
        {
            for (int light = 0; light < lightningCount; light++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int node = tokens[0];
                int dmg = tokens[1];

                Prim(node, dmg);
            }
        }

        private static void ReadInput()
        {
            graph = new Dictionary<int, List<Edge>>();
            damages = new Dictionary<int, long>();
            lightnings = new List<string>();

            int nodeCount = int.Parse(Console.ReadLine());

            int edgeCount = int.Parse(Console.ReadLine());

            lightningCount = int.Parse(Console.ReadLine());

            for (int node = 0; node < nodeCount; node++)
            {
                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<Edge>();
                    damages[node] = 0;
                }
            }

            for (int currEdge = 0; currEdge < edgeCount; currEdge++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = tokens[0];
                int secondNode = tokens[1];
                int distance = tokens[2];

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<Edge>();
                    damages[firstNode] = 0;
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<Edge>();
                    damages[secondNode] = 0;
                }

                Edge edge = new Edge()
                {
                    StartNode = firstNode,
                    EndNode = secondNode,
                    Distance = distance
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }

        public static void Prim(int startNode, int damage)
        {
            var queue = new OrderedBag<Edge>();

            HashSet<int> spanningTree = new HashSet<int>();
            Dictionary<int, long> currentDmgs = new Dictionary<int, long>();

            currentDmgs[startNode] = damage;
            damages[startNode] += damage;
            spanningTree.Add(startNode);
            queue.AddMany(graph[startNode]);

            while (queue.Count > 0)
            {
                var minEdge = queue.GetFirst();
                queue.RemoveFirst();

                int firstNode = minEdge.StartNode;
                int secondNode = minEdge.EndNode;

                int treeNode = -1;
                int nonTreeNode = -1;

                if (spanningTree.Contains(firstNode) &&
                   !spanningTree.Contains(secondNode))
                {
                    treeNode = firstNode;
                    nonTreeNode = secondNode;
                }
                else if (spanningTree.Contains(secondNode) &&
                   !spanningTree.Contains(firstNode))
                {
                    treeNode = secondNode;
                    nonTreeNode = firstNode;
                }
                else if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);
                if (!currentDmgs.ContainsKey(nonTreeNode))
                {
                    currentDmgs[nonTreeNode] = 0;
                }
                currentDmgs[nonTreeNode] = currentDmgs[treeNode] / 2;
                damages[nonTreeNode] += currentDmgs[nonTreeNode];
                queue.AddMany(graph[nonTreeNode]);
                //if (currentDmgs[nonTreeNode] == 0)
                //{
                //    break;
                //}
            }
        }

        public class Edge : IComparable<Edge>
        {
            public int StartNode { get; set; }

            public int EndNode { get; set; }

            public int Distance { get; set; }

            public Edge()
            {

            }

            public Edge(int startNode, int endNode, int distance)
            {
                this.StartNode = startNode;
                this.EndNode = endNode;
                this.Distance = distance;
            }

            public int CompareTo(Edge other)
            {
                return this.Distance - other.Distance;
            }
        }
    }
}
