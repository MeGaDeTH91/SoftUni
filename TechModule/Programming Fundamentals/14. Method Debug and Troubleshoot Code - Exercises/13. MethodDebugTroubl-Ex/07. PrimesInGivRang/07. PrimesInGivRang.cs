using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrimesInGivRang
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            var primes = ShowPrimesInRange(start, end);
            if (start > end)
            {
                Console.WriteLine("(empty list)");
            }
            else
            {
                Console.WriteLine(string.Join(", ", primes));
            }


        }
        static List<int> ShowPrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int currNum = start; currNum <= end; currNum++)
            {
                if (IsPrime(currNum))
                {
                    primes.Add(currNum);
                }
            }
            return primes;
        }
        static bool IsPrime(long n)
        {

            long range = (long)Math.Sqrt(n);
            if (n == 2)
            {
                return true;
            }
            else if (n > 1)
            {
                for (int i = 2; i <= range; i++)
                {
                    if (n % i == 0)
                    {
                        return false;

                    }
                }
            }
            else if (n <= 1)
            {
                return false;
            }
            return true;
        }
    }
}
