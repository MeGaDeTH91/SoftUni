using System.Collections.Generic;

public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
    {
        int?[] previous = new int?[graph.Count];
        bool[] visited = new bool[graph.Count];

        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        sourceNode.DistanceFromStart = 0;
        queue.Enqueue(sourceNode);

        while (queue.Count > 0)
        {
            Node min = queue.ExtractMin();

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
}
