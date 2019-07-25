namespace _05.EgyptianFracs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static IList<string> resultFractions = new List<string>();

        public static void Main()
        {
            string inputLine = Console.ReadLine();
            string[] lineTokens = inputLine
                .Split(new[] { "/", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int numerator = int.Parse(lineTokens[0]);
            int denumerator = int.Parse(lineTokens[1]);

            double result = numerator / denumerator;

            if(result >= 1)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
            }
            else
            {
                FindEgyptianFractions(numerator, denumerator);
                Console.WriteLine($"{inputLine} = {string.Join(" + ", resultFractions)}");
            }
        }

        private static void FindEgyptianFractions(int numerator, int denumerator)
        {
            int fractionDenumerator = 2;

            while (numerator > 0)
            {
                int nextNumerator = numerator * fractionDenumerator;
                int fractionNumerator = denumerator;

                int diff = nextNumerator - fractionNumerator;

                if(diff >= 0)
                {
                    resultFractions.Add($"1/{fractionDenumerator}");
                    numerator = diff;
                    denumerator *= fractionDenumerator;
                }
                fractionDenumerator++;
            }
        }
    }
}
