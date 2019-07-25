namespace _04.HanoiTowers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Stack<int> source = new Stack<int>();
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        private const string sourceStr = "Source: ";
        private const string destinationStr = "Destination: ";
        private const string spareStr = "Spare: ";

        private static int steps = 0;

        public static void Main()
        {
            int towersCount = int.Parse(Console.ReadLine());
            InitializeSource(towersCount);

            PrintAllTowers(1);
            SolveHanoi(towersCount, source, destination, spare);
        }
        
        private static void SolveHanoi(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            
            if(bottomDisk == 1)
            {
                steps++;
                destination.Push(source.Pop());
                PrintAllTowers(bottomDisk);
            }
            else
            {
                SolveHanoi(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());

                steps++;
                PrintAllTowers(bottomDisk);
                SolveHanoi(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintAllTowers(int bottomDisk)
        {
            if(steps > 0)
            {
                Console.WriteLine($"Step #{steps}: Moved disk");
            }
            PrintTower(sourceStr, source);
            PrintTower(destinationStr, destination);
            PrintTower(spareStr, spare);
            Console.WriteLine();
        }

        private static void InitializeSource(int count)
        {
            for (int i = count; i > 0; i--)
            {
                source.Push(i);
            }
        }

        private static void PrintTower(string name, Stack<int> tower)
        {
            List<int> result = tower.Reverse().ToList();

            Console.WriteLine($"{name}{string.Join(", ", result)}");
        }
    }
}
