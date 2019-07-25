namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<int, List<int>> emps;
        private static Dictionary<int, long> salaries;
        private static Dictionary<int, bool> visited;
        
        public static void Main()
        {
            ReadInput();

            foreach (var node in emps)
            {
                if (!visited[node.Key])
                {
                    TraverseDFS(node.Key);
                }
            }

            Console.WriteLine(salaries.Values.Sum());
        }

        private static void TraverseDFS(int node)
        {
            
            
            if(emps[node].Count < 1)
            {
                salaries[node] = 1;
                return;
            }

            visited[node] = true;

            long sum = 0;
            foreach (var child in emps[node])
            {
                if (!visited[child])
                {
                    TraverseDFS(child);
                }
                sum += salaries[child];
            }
            salaries[node] = sum;
        }

        private static void ReadInput()
        {
            emps = new Dictionary<int, List<int>>();
            salaries = new Dictionary<int, long>();
            visited = new Dictionary<int, bool>();

            int n = int.Parse(Console.ReadLine());

            for (int node = 0; node < n; node++)
            {
                emps[node] = new List<int>();
                salaries[node] = 0;
                visited[node] = false;

                var tokens = Console.ReadLine().ToCharArray();
                
                for (int child = 0; child < n; child++)
                {
                    char current = tokens[child];

                    if (current == 'Y')
                    {
                        emps[node].Add(child);
                    }
                }
            }
        }
    }
}
