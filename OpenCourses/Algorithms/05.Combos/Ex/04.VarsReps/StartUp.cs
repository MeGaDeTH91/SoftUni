﻿namespace _04.VarsReps
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] set;
        private static string[] vector;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int vectorSize = int.Parse(Console.ReadLine());
            vector = new string[vectorSize];

            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    Variate(index + 1);
                }
            }
        }
    }
}
