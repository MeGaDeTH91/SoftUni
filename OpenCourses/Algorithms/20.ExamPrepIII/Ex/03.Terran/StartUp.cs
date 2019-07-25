namespace _03.Terran
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        private static int[] set;
        private static int counter;

        public static void Main()
        {
            char[] temp = Console.ReadLine()
                .ToCharArray();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var element in temp)
            {
                if (!counts.ContainsKey(element))
                {
                    counts[element] = 0;
                }

                counts[element]++;
            }

            BigInteger factorial = 1;

            for (int i = temp.Length; i >= 1; i--)
            {
                factorial *= i;
            }
            
            foreach (var element in counts)
            {
                for (int i = element.Value; i >= 1; i--)
                {
                    factorial /= i;
                }
            }

            Console.WriteLine(factorial);
        }
    }
}
