namespace _03.TourDeSofia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        private static bool[] visited;
        private static int[] lengths;
        private static int result;

        public static void Main()
        {
            int startNode = ReadInput();

            TraverseGraph(startNode);

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(result);
        }

        private static void TraverseGraph(int startNode)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startNode);
            bool hasPath = false;

            while (queue.Count > 0 && !hasPath)
            {
                int node = queue.Dequeue();

                visited[node] = true;

                foreach (var child in graph[node])
                {
                    if(child == startNode)
                    {
                        result = lengths[node] + 1;
                        hasPath = true;
                        break;
                    }
                    if (!visited[child])
                    {
                        visited[child] = true;
                        lengths[child] = lengths[node] + 1;

                        queue.Enqueue(child);
                    }
                }
            }

            if(result == -1)
            {
                result = lengths.Count(x => x > 0) + 1;
            }
        }

        private static int ReadInput()
        {
            int nodeCount = int.Parse(Console.ReadLine());

            int streetCount = int.Parse(Console.ReadLine());

            int startNode = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            visited = new bool[nodeCount];
            lengths = new int[nodeCount];
            result = -1;

            for (int i = 0; i < streetCount; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = tokens[0];
                int secondNode = tokens[1];

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<int>();
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<int>();
                }
                graph[firstNode].Add(secondNode);
            }
            return startNode;
        }
    }
}
