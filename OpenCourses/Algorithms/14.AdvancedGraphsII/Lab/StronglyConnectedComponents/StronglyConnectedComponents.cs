using System;
using System.Collections.Generic;
using System.Linq;

public class StronglyConnectedComponents
{
    private static int size;
    private static bool[] visited;
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static Stack<int> dfsNodes;

    private static List<List<int>> stronglyConnectedComponents;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        stronglyConnectedComponents = new List<List<int>>();
        graph = targetGraph;
        size = graph.Length;
        BuildReverseGraph();
        visited = new bool[size];
        dfsNodes = new Stack<int>();

        for (int i = 0; i < size; i++)
        {
            if (!visited[i])
            {
                DFS(i);
            }
        }

        visited = new bool[size];

        while (dfsNodes.Count > 0)
        {
            var node = dfsNodes.Pop();

            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());

                ReverseDFS(node);
            }
        }

        return stronglyConnectedComponents;
    }

    private static void ReverseDFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents.Last().Add(node);

            foreach (var child in reverseGraph[node])
            {
                ReverseDFS(child);
            }
        }
    }

    private static void BuildReverseGraph()
    {
        reverseGraph = new List<int>[size];

        for (int node = 0; node < size; node++)
        {
            reverseGraph[node] = new List<int>();
        }

        for (int node = 0; node < size; node++)
        {
            foreach (var child in graph[node])
            {
                reverseGraph[child].Add(node);
            }
        }
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            dfsNodes.Push(node);
        }
    }
}
