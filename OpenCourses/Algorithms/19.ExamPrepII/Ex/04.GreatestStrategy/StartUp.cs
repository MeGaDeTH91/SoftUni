namespace _04.GreatestStrategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, List<int>> discGraph;
        private static HashSet<int> visited;
        private static int root;
        private static int max;

        public static void Main()
        {
            ReadInput();

            Traverse();

            PrintResult();
        }

        private static void Traverse()
        {
            DFS(root, root);

            var visited = new HashSet<int>();

            foreach (var key in discGraph.Keys)
            {
                if (!visited.Contains(key))
                {
                    int value = GetValue(key, visited);

                    if(value > max)
                    {
                        max = value;
                    }
                }
            }
        }

        private static int GetValue(int key, HashSet<int> visited)
        {
            visited.Add(key);

            int value = 0;

            foreach (var child in discGraph[key])
            {
                if (!visited.Contains(child))
                {
                    value += GetValue(child, visited);
                }
            }
            return value + key;
        }

        private static int DFS(int node, int parent)
        {
            visited.Add(node);

            int count = 1;

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child) && child != parent)
                {
                    int subNodes = DFS(child, node);
                    int num = graph[child].Count - 1;

                    if(subNodes % 2 == 0)
                    {
                        discGraph[node].Remove(child);
                        discGraph[child].Remove(node);
                    }
                    count += subNodes;
                }
            }

            return count; 
        }

        private static void PrintResult()
        {
            Console.WriteLine(max);
        }

        private static void ReadInput()
        {
            graph = new Dictionary<int, List<int>>();
            discGraph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();

            int[] tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int areaCount = tokens[0];
            int connectionCount = tokens[1];
            root = tokens[2];

            for (int conn = 0; conn < connectionCount; conn++)
            {
                int[] connTokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int firstNode = connTokens[0];
                int secondNode = connTokens[1];

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<int>();
                    discGraph[firstNode] = new List<int>();
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<int>();
                    discGraph[secondNode] = new List<int>();
                }

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                discGraph[firstNode].Add(secondNode);
                discGraph[secondNode].Add(firstNode);
            }
            
        }
    }
}
