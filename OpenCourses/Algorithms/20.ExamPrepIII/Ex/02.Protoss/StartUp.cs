namespace _02.Protoss
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static char[][] matrix;
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, int> counts;

        public static void Main()
        {
            ReadInput();

            foreach (var node in graph)
            {
                CountConnections(node.Key);
            }

            Console.WriteLine(counts.Values.Max());
        }

        private static void CountConnections(int node)
        {
            int count = 0;

            count += graph[node].Count;

            HashSet<int> visited = new HashSet<int>();
            visited.Add(node);

            foreach (var child in graph[node])
            {
                foreach (var nested in graph[child])
                {
                    if (!graph[nested].Contains(node) && !visited.Contains(nested))
                    {
                        count++;
                        visited.Add(nested);
                    }
                }
            }

            counts[node] = count;
        }

        private static void ReadInput()
        {
            int zealotCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            counts = new Dictionary<int, int>();
            matrix = new char[zealotCount][];

            for (int row = 0; row < zealotCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                if (!graph.ContainsKey(row))
                {
                    graph[row] = new List<int>();
                    counts[row] = 0;
                }
            }

            for (int row = 0; row < zealotCount; row++)
            {
                for (int col = 0; col < zealotCount; col++)
                {
                    var element = matrix[row][col];

                    if (element == 'Y')
                    {
                        graph[row].Add(col);
                    }
                }
            }
        }
    }
}
