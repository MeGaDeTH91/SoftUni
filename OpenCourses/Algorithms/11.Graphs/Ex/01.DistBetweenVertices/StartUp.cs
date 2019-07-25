using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static Dictionary<int, List<int>> graph;

    public static void Main()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        int pairSearchCount = int.Parse(Console.ReadLine());
        graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < nodeCount; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(':')
                .ToArray();

            int first = int.Parse(tokens[0]);

            if (!graph.ContainsKey(first))
            {
                graph[first] = new List<int>();
            }
            if (!string.IsNullOrWhiteSpace(tokens[1]))
            {
                var second = tokens[1].Split(' ')
                .Select(int.Parse);
                graph[first].AddRange(second.ToList());
            }


        }

        for (int i = 0; i < pairSearchCount; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split('-')
                .ToArray();

            int first = int.Parse(tokens[0]);
            var second = int.Parse(tokens[1]);

            int result = HasPath(first, second);

            Console.WriteLine($"{{{first}, {second}}} -> {result}");
        }

    }

    private static int HasPath(int start, int end)
    {
        Dictionary<int, int> levels = new Dictionary<int, int>();
        Dictionary<int, bool> visited = new Dictionary<int, bool>();

        Queue<int> queue = new Queue<int>();
        foreach (var node in graph.Keys.ToList())
        {
            visited[node] = false;
            levels[node] = int.MaxValue;
        }
        visited[start] = true;
        levels[start] = 0;

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            visited[node] = true;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    if(levels[node] + 1 < levels[child])
                    {
                        levels[child] = levels[node] + 1;
                    }
                    
                    queue.Enqueue(child);
                }
            }
        }
        if(levels[end] != int.MaxValue)
        {
            return levels[end];
        }
        return -1;
    }
}

