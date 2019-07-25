namespace _04.Molecules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<Node, Dictionary<Node, int>> graph;
        private static Dictionary<int, Node> nodes;
        private static HashSet<int> allNodes;
        private static SortedSet<int> unvisited;
        private static int startMolecule = 0;
        private static int endMolecule = 0;

        public static void Main()
        {
            ReadInput();

            Node startNode = nodes[startMolecule];
            Node endNode = nodes[endMolecule];
            
            var result = DijkstraAlgorithm(graph, startNode, endNode);
            
            PrintResult(result);
        }

        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            int?[] previous = new int?[graph.Count + 1];
            bool[] visited = new bool[graph.Count + 1];

            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            sourceNode.DistanceFromStart = 0;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                Node min = queue.ExtractMin();
                
                unvisited.Remove(min.Id);
                
                foreach (var child in graph[min])
                {
                    if (!visited[child.Key.Id])
                    {
                        queue.Enqueue(child.Key);
                        visited[child.Key.Id] = true;
                    }
                    var distance = double.PositiveInfinity;

                    distance = child.Value + min.DistanceFromStart;

                    if (distance < child.Key.DistanceFromStart)
                    {
                        child.Key.DistanceFromStart = distance;

                        previous[child.Key.Id] = min.Id;
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

        private static void PrintResult(List<int> result)
        {
            int sum = 0;

            for (int i = 1; i < result.Count; i++)
            {
                int prev = result[i - 1];
                int current = result[i];

                Node first = nodes[prev];
                Node second = nodes[current];

                sum += graph[first][second];
            }
            Console.WriteLine(sum);

            Console.WriteLine(string.Join(" ", unvisited));
        }

        private static void ReadInput()
        {
            graph = new Dictionary<Node, Dictionary<Node, int>>();
            nodes = new Dictionary<int, Node>();
            unvisited = new SortedSet<int>();

            int nodeCount = int.Parse(Console.ReadLine());
            
            int edgeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgeCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int firstNode = int.Parse(tokens[0]);
                int secondNode = int.Parse(tokens[1]);

                if (!nodes.ContainsKey(firstNode))
                {
                    nodes.Add(firstNode, new Node(firstNode));
                    unvisited.Add(firstNode);
                }
                if (!nodes.ContainsKey(secondNode))
                {
                    nodes.Add(secondNode, new Node(secondNode));
                    unvisited.Add(secondNode);
                }

                int cost = int.Parse(tokens[2]);

                if (!graph.ContainsKey(nodes[firstNode]))
                {
                    graph[nodes[firstNode]] = new Dictionary<Node, int>();
                }
                if (!graph.ContainsKey(nodes[secondNode]))
                {
                    graph[nodes[secondNode]] = new Dictionary<Node, int>();
                }

                graph[nodes[firstNode]].Add(nodes[secondNode], cost);
            }

            int[] pathTokens = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            startMolecule = pathTokens[0];
            endMolecule = pathTokens[1];
        }

        public class Node : IComparable<Node>
        {
            // set default value for the distance equal to positive infinity
            public Node(int id, double distance = double.PositiveInfinity)
            {
                this.Id = id;
                this.DistanceFromStart = distance;
            }

            public int Id { get; set; }

            public double DistanceFromStart { get; set; }

            public int CompareTo(Node other)
            {
                return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
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

            public T ExtractMin()
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
