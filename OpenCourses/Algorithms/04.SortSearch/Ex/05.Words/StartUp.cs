namespace _05.Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static char[] elements;
        private static int count;

        public static void Main()
        {
            elements = Console.ReadLine().ToCharArray();

            var distinctElements = elements.Distinct().Count();

            if(distinctElements == elements.Length)
            {
                int multy = 1;
                for (int i = 1; i <= elements.Length; i++)
                {
                    multy *= i;
                }
                Console.WriteLine(multy);
                return;
            }
            Permutate(0);

            Console.WriteLine(count);
        }

        private static void Permutate(int index)
        {
            if(index >= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if(elements[i] == elements[i - 1])
                    {
                        return;
                    }
                }
                count++;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permutate(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            char temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
