namespace _07.NChooseKCount
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<decimal, Dictionary<decimal, decimal>> memo = new Dictionary<decimal, Dictionary<decimal, decimal>>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            decimal result = Binom(n, k);

            Console.WriteLine(result);
        }

        private static decimal Binom(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            if (!memo.ContainsKey(n))
            {
                memo[n] = new Dictionary<decimal, decimal>();
                
            }

            if (!memo[n].ContainsKey(k))
            {
                memo[n][k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
                return memo[n][k];
            }
            else
            {
                return memo[n][k];
            }
            
        }
    }
}
