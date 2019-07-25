namespace _02.ModdedKruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int nodeCount = int.Parse(Console.ReadLine()
                .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[1]);

            int edgeCount = int.Parse(Console.ReadLine()
                .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[1]);

            List<Edge> allEdges = new List<Edge>();

            for (int currEdge = 0; currEdge < edgeCount; currEdge++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Edge edge = new Edge(tokens[0], tokens[1], tokens[2]);

                allEdges.Add(edge);
            }

            var result = Kruskal(edgeCount, allEdges);

            Console.WriteLine($"Minimum spanning forest weight: {result.Sum(x => x.Weight)}");

            //Console.WriteLine(string.Join(Environment.NewLine, result));
        }

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

                if (startRoot != endRoot)
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

        public class Edge : IComparable<Edge>
        {
            public Edge(int startNode, int endNode, int weight)
            {
                this.StartNode = startNode;
                this.EndNode = endNode;
                this.Weight = weight;
            }

            public int StartNode { get; set; }

            public int EndNode { get; set; }

            public int Weight { get; set; }

            public int CompareTo(Edge other)
            {
                return this.Weight.CompareTo(other.Weight);
            }

            public override string ToString()
            {
                return $"({this.StartNode} {this.EndNode}) -> {this.Weight}";
            }
        }
    }
}
