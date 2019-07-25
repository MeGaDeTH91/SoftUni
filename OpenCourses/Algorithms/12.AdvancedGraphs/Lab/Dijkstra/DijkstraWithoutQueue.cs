using System;
using System.Collections.Generic;

public static class DijkstraWithoutQueue
{
    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        int nodeCount = graph.GetLength(0);

        int[] distance = new int[nodeCount];
        bool[] used = new bool[nodeCount];
        int?[] prev = new int?[nodeCount];
        for (int node = 0; node < nodeCount; node++)
        {
            distance[node] = int.MaxValue;
        }
        distance[sourceNode] = 0;

        while (true)
        {
            int minDistance = int.MaxValue;
            int minNode = 0;

            for (int node = 0; node < nodeCount; node++)
            {
                if(!used[node] && distance[node] < minDistance)
                {
                    minDistance = distance[node];
                    minNode = node;
                }
            }

            if(minDistance == int.MaxValue)
            {
                break;
            }
            used[minNode] = true;

            for (int i = 0; i < nodeCount; i++)
            {
                if(graph[minNode, i] > 0)
                {
                    if(graph[minNode, i] + distance[minNode] < distance[i])
                    {
                        distance[i] = graph[minNode, i] + distance[minNode];
                        prev[i] = minNode;
                    }
                }
            }
        }

        if(distance[destinationNode] == int.MaxValue)
        {
            return null;
        }

        List<int> path = new List<int>();
        int? currentNode = destinationNode;

        while (currentNode != null)
        {
            path.Add(currentNode.Value);
            currentNode = prev[currentNode.Value];
        }

        path.Reverse();

        return path;
    }
}