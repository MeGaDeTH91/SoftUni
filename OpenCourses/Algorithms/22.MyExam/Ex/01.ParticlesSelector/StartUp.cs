namespace _01.ParticlesSelector
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            BigInteger setLength = BigInteger.Parse(Console.ReadLine());

            BigInteger vectorSize = BigInteger.Parse(Console.ReadLine());

            BigInteger result = Combinations(setLength, vectorSize);

            Console.WriteLine(result);
        }

        public static BigInteger Combinations(BigInteger n, BigInteger k)
        {
            BigInteger upper = 1;
            BigInteger bottom1 = 1;
            BigInteger bottom2 = 1;
            
            for (BigInteger i = n; i > 0; i--)
            {
                upper = upper * i;
            }

            for (BigInteger i = k; i > 0; i--)
            {
                bottom1 = bottom1 * i;
            }
            for (BigInteger i = n - k; i > 0; i--)
            {
                bottom2 = bottom2 * i;
            }

            BigInteger bottom = bottom1 * bottom2;

            return upper / bottom;
        }
    }
}
