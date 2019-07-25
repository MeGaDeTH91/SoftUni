namespace _01.PermsNoReps
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] set;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if(index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
            }
            else
            {
                Permute(index + 1);

                for (int i = index + 1; i < set.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            string element = set[index];
            set[index] = set[i];
            set[i] = element;
        }
    }
}
