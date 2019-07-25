using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static int?[] parents;
    private static int[] lowpoints;
    private static int[] depths;
    private static bool[] visited;

    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        parents = new int?[graph.Length];
        lowpoints = new int[graph.Length];
        depths = new int[graph.Length];
        visited = new bool[graph.Length];
        articulationPoints = new List<int>();

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                FindArticulationPoints(node, 1);
            }
        }

        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoints[node] = depth;

        int childCount = 0;
        bool isArticulationPoint = false;

        foreach (var childNode in graph[node])
        {
            if (!visited[childNode])
            {
                parents[childNode] = node;
                FindArticulationPoints(childNode, depth + 1);
                childCount++;
                if(lowpoints[childNode] >= depths[node])
                {
                    isArticulationPoint = true;
                }
                lowpoints[node] = Math.Min(lowpoints[node], lowpoints[childNode]);
            }
            else if(parents[node] != childNode)
            {
                lowpoints[node] = Math.Min(lowpoints[node], depths[childNode]);
            }
        }
        if ((parents[node] != null && isArticulationPoint) ||
               (parents[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }
    }
}
