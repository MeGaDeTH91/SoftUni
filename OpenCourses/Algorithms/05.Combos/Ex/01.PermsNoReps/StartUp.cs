namespace _01.PermsNoReps
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static char[] set;
        private static int[] swappingsArr;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            swappingsArr = Enumerable.Range(0, set.Length).ToArray();

            char[] perm = Next();

            while (perm != null)
            {
                Print(perm);
                perm = Next();
            }
        }

        private static char[] Next()
        {
            if (set == null)
            {
                return null;
            }

            char[] result = new char[set.Length];
            Array.Copy(set, result, set.Length);

            int index = swappingsArr.Length - 1;

            while (index >= 0 && swappingsArr[index] == set.Length - 1)
            {
                Swap(index, swappingsArr[index]);
                swappingsArr[index] = index;
                index--;
            }

            if(index < 0)
            {
                set = null;
            }
            else
            {
                int prev = swappingsArr[index];
                Swap(index, prev);
                int next = prev + 1;
                swappingsArr[index] = next;
                Swap(index, next);
            }

            return result;
        }

        private static void Print(char[] perm)
        {
            Console.WriteLine(string.Join(" ", perm));
        }

        private static void Swap(int index, int i)
        {
            char element = set[index];
            set[index] = set[i];
            set[i] = element;
        }
    }
}
