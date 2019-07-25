using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static Dictionary<string, List<string>> graph;
    private static HashSet<string> visitedNodes;
    private static HashSet<string> currentVisited;
    private static bool hasCycles = false;

    public static void Main()
    {
        ReadInput();

        foreach (var node in graph)
        {
            CheckForCycle(node.Key, null);
        }

        string result = hasCycles ? "Acyclic: No" : "Acyclic: Yes";
        Console.WriteLine(result);
    }
    
    private static void ReadInput()
    {
        graph = new Dictionary<string, List<string>>();
        currentVisited = new HashSet<string>();
        visitedNodes = new HashSet<string>();

        string input;
        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            string[] tokens = input
                //.Split('-')
                .Split('–')
                .ToArray();

            string first = tokens[0];
            string second = tokens[1];

            if (!graph.ContainsKey(first))
            {
                graph[first] = new List<string>();
            }
            if (!graph.ContainsKey(second))
            {
                graph[second] = new List<string>();
            }

            graph[first].Add(second);
            graph[second].Add(first);
        }
        
    }

    private static void CheckForCycle(string node, string parent)
    {
        if (currentVisited.Contains(node))
        {
            hasCycles = true;
            return;
        }
        if(visitedNodes.Contains(node) || hasCycles)
        {
            return;
        }

        visitedNodes.Add(node);
        currentVisited.Add(node);

        foreach (var child in graph[node])
        {
            if(child != parent)
            {
                CheckForCycle(child, node);
            }
        }

        currentVisited.Remove(node);
    }
}
