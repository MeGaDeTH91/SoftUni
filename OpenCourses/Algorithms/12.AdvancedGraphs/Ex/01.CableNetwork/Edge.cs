namespace _01.CableNetwork
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Cost { get; set; }

        public Edge()
        {

        }

        public Edge(int startNode, int endNode, int cost)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Cost = cost;
        }

        public int CompareTo(Edge other)
        {
            return this.Cost - other.Cost;
        }
    }
}
