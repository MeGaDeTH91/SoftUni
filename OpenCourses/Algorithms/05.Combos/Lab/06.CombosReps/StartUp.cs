namespace _06.CombosReps
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

            Combinate(0, 0);
        }

        private static void Combinate(int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    Combinate(index + 1, i);
                }
            }
        }
    }
}
