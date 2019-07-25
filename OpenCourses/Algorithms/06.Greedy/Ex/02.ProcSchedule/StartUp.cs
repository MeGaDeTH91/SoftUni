namespace _02.ProcSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static IList<Task> initialList;
        private static IList<Task> taskList = new List<Task>();
        private static IList<Task> resultList = new List<Task>();
        private static double totalValue = 0.0d;

        public static void Main()
        {
            ReadInput();

            SetSchedule();
            resultList = resultList.OrderBy(x => x.Deadline).ToList();

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", resultList.Select(x => initialList.IndexOf(x) + 1))}");

            Console.WriteLine($"Total value: {totalValue}");
        }

        private static void SetSchedule()
        {
            int step = taskList.Max(x => x.Deadline);

            for (int i = 1; i <= step; i++)
            {
                Task currentBest = taskList.Where(x => x.Deadline <= i + 1).OrderByDescending(x => x.Value).First();

                totalValue += currentBest.Value;
                int taskIndex = taskList.IndexOf(currentBest);
                resultList.Add(currentBest);
                taskList.RemoveAt(taskIndex);
            }
        }

        private static void ReadInput()
        {
            int taskCount = int.Parse(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            for (int i = 0; i < taskCount; i++)
            {
                string[] currentTokens = Console.ReadLine()
                    .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Task currentItem = new Task()
                {
                    Value = int.Parse(currentTokens[0]),
                    Deadline = int.Parse(currentTokens[1])
                };

                taskList.Add(currentItem);
            }
            initialList = new List<Task>(taskList);
        }

        private class Task
        {
            public int Value { get; set; }

            public int Deadline { get; set; }
        }
    }
}
