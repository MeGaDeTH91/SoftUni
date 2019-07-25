namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int pathStart = 0;
        private static int pathEnd = 0;

        public static void Main()
        {
            Dictionary<Node, Dictionary<Node, int>> graph = ReadInput();

            Node start = graph.Keys.FirstOrDefault(x => x.Id == pathStart);
            Node end = graph.Keys.FirstOrDefault(x => x.Id == pathEnd);

            var result = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, start, end);

            double percentageResult = graph.Keys.FirstOrDefault(x => x.Id == result.Last()).DistanceFromStart;

            Console.WriteLine($"Most reliable path reliability: {percentageResult:F2}%");

            Console.WriteLine(string.Join(" -> ", result));
        }

        private static Dictionary<Node, Dictionary<Node, int>> ReadInput()
        {
            Dictionary<Node, Dictionary<Node, int>> graph = new Dictionary<Node, Dictionary<Node, int>>();

            int nodeCount = int.Parse(Console.ReadLine()
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[1]);

            for (int i = 0; i < nodeCount; i++)
            {
                Node node = new Node(i);
                graph[node] = new Dictionary<Node, int>();
            }

            string[] pathTokens = Console.ReadLine()
                .Split(new[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            pathStart = int.Parse(pathTokens[1]);
            pathEnd = int.Parse(pathTokens[2]);

            int edgeCount = int.Parse(Console.ReadLine()
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[1]);

            for (int i = 0; i < edgeCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int startNode = int.Parse(tokens[0]);
                int endNode = int.Parse(tokens[1]);
                int weight = int.Parse(tokens[2]);

                Node firstNode = graph.Keys.FirstOrDefault(x => x.Id == startNode);

                Node secondNode = graph.Keys.FirstOrDefault(x => x.Id == endNode);

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new Dictionary<Node, int>();
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new Dictionary<Node, int>();
                }
                graph[firstNode].Add(secondNode, weight);
                graph[secondNode].Add(firstNode, weight);
            }

            return graph;
        }

        public static class DijkstraWithPriorityQueue
        {
            public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
            {
                int?[] previous = new int?[graph.Count];
                bool[] visited = new bool[graph.Count];

                PriorityQueue<Node> queue = new PriorityQueue<Node>();

                sourceNode.DistanceFromStart = 100;
                queue.Enqueue(sourceNode);

                while (queue.Count > 0)
                {
                    Node max = queue.ExtractMax();

                    foreach (var child in graph[max])
                    {
                        if (!visited[child.Key.Id])
                        {
                            queue.Enqueue(child.Key);
                            visited[child.Key.Id] = true;
                        }
                        var distance = double.NegativeInfinity;

                        distance = (child.Value * max.DistanceFromStart) / 100;

                        if (distance > child.Key.DistanceFromStart)
                        {
                            child.Key.DistanceFromStart = distance;

                            previous[child.Key.Id] = max.Id;
                            queue.DecreaseKey(child.Key);
                        }
                    }
                }

                if (double.IsInfinity(destinationNode.DistanceFromStart))
                {
                    return null;
                }

                List<int> path = new List<int>();
                int? currentNode = destinationNode.Id;

                while (currentNode != null)
                {
                    path.Add(currentNode.Value);
                    currentNode = previous[currentNode.Value];
                }

                path.Reverse();

                return path;
            }
        }

        public class Node : IComparable<Node>
        {
            // set default value for the distance equal to positive infinity
            public Node(int id, double distance = double.NegativeInfinity)
            {
                this.Id = id;
                this.DistanceFromStart = distance;
            }

            public int Id { get; set; }

            public double DistanceFromStart { get; set; }

            public int CompareTo(Node other)
            {
                return other.DistanceFromStart.CompareTo(this.DistanceFromStart);
            }
        }
        public class PriorityQueue<T> where T : IComparable<T>
        {
            private Dictionary<T, int> searchCollection;
            private List<T> heap;

            public PriorityQueue()
            {
                this.heap = new List<T>();
                this.searchCollection = new Dictionary<T, int>();
            }

            public int Count
            {
                get
                {
                    return this.heap.Count;
                }
            }

            public T ExtractMax()
            {
                var min = this.heap[0];
                var last = this.heap[this.heap.Count - 1];
                this.searchCollection[last] = 0;
                this.heap[0] = last;
                this.heap.RemoveAt(this.heap.Count - 1);
                if (this.heap.Count > 0)
                {
                    this.HeapifyDown(0);
                }

                this.searchCollection.Remove(min);

                return min;
            }

            public T PeekMin()
            {
                return this.heap[0];
            }

            public void Enqueue(T element)
            {
                this.searchCollection.Add(element, this.heap.Count);
                this.heap.Add(element);
                this.HeapifyUp(this.heap.Count - 1);
            }

            private void HeapifyDown(int i)
            {
                var left = (2 * i) + 1;
                var right = (2 * i) + 2;
                var smallest = i;

                if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = left;
                }

                if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = right;
                }

                if (smallest != i)
                {
                    T old = this.heap[i];
                    this.searchCollection[old] = smallest;
                    this.searchCollection[this.heap[smallest]] = i;
                    this.heap[i] = this.heap[smallest];
                    this.heap[smallest] = old;
                    this.HeapifyDown(smallest);
                }
            }

            private void HeapifyUp(int i)
            {
                var parent = (i - 1) / 2;
                while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
                {
                    T old = this.heap[i];
                    this.searchCollection[old] = parent;
                    this.searchCollection[this.heap[parent]] = i;
                    this.heap[i] = this.heap[parent];
                    this.heap[parent] = old;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }

            public void DecreaseKey(T element)
            {
                int index = this.searchCollection[element];
                this.HeapifyUp(index);
            }
        }
    }
}
