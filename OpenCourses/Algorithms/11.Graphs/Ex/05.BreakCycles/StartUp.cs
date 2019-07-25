namespace _05.BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static SortedDictionary<string, List<string>> graph;
        private static HashSet<string> visitedNodes;
        private static HashSet<string> reversedCombos;
        private static List<string> result;

        public static void Main()
        {
            ReadInput();

            TraverseGraph();

            PrintResult();
        }

        private static void CheckForCycle(string node)
        {
            foreach (var child in graph[node].OrderBy(x => x).ToList())
            {
                visitedNodes = new HashSet<string>();

                if (!visitedNodes.Contains(child))
                {
                    graph[node].Remove(child);
                    graph[child].Remove(node);
                    
                    if(HasPath(node, child))
                    {
                        result.Add($"{node} - {child}");
                    }
                    else
                    {
                        graph[node].Add(child);
                        graph[child].Add(node);
                    }
                }
            }
        }

        private static bool HasPath(string start, string end)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(start);

            visitedNodes.Add(start);

            while (stack.Count > 0)
            {
                string node = stack.Pop();

                foreach (var child in graph[node].OrderBy(x => x).ToList())
                {
                    if (!visitedNodes.Contains(child))
                    {
                        if(child == end)
                        {
                            return true;
                        }
                        visitedNodes.Add(child);
                        stack.Push(child);
                    }
                }
            }

            return false;
        }

        private static void ReadInput()
        {
            graph = new SortedDictionary<string, List<string>>();
            reversedCombos = new HashSet<string>();
            visitedNodes = new HashSet<string>();
            result = new List<string>();

            string input;
            while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                string[] tokens = input
                    .Split(new[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentNode = tokens[0];

                graph[currentNode] = tokens.Skip(1).ToList();

            }

        }

        private static void TraverseGraph()
        {
            foreach (var node in graph)
            {
                CheckForCycle(node.Key);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Edges to remove: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
        
    }
}
