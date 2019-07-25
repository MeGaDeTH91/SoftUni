namespace _04.XelNaga
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] inputTokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, int> pairs = new Dictionary<int, int>();

            int minRaces = 0;

            for (int i = 0; i < inputTokens.Length - 1; i++)
            {
                int element = inputTokens[i];

                if (!pairs.ContainsKey(element))
                {
                    pairs[element] = element;
                    minRaces += element + 1;
                }
                else
                {
                    if (pairs[element] == 0)
                    {
                        pairs[element] = element;
                        minRaces += element + 1;
                    }
                    else
                    {
                        pairs[element]--;
                    }
                }
                
            }
            
            Console.WriteLine(minRaces);
        }
    }
}
