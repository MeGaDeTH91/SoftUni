
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();

            int[] allEdges = edges.Select(x => x.StartNode).Union(edges.Select(x => x.EndNode))
                .Distinct().ToArray();

            Array.Sort<int>(allEdges);

            int[] parents = new int[allEdges.Length];

            for (int i = 0; i < allEdges.Length; i++)
            {
                int root = allEdges[i];
                parents[root] = root;
            }

            List<Edge> result = new List<Edge>();

            foreach (var edge in edges)
            {
                int startRoot = FindRoot(edge.StartNode, parents);
                int endRoot = FindRoot(edge.EndNode, parents);

                if(startRoot != endRoot)
                {
                    result.Add(edge);
                    parents[endRoot] = startRoot; 
                }
            }
            return result;
        }

        public static int FindRoot(int node, int[] parent)
        {
            while (parent[node] != node)
            {
                node = parent[node];
            }

            return node;
        }
    }

