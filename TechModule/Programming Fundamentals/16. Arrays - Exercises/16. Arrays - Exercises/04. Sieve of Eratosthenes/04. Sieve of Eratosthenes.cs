using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            bool[] primes = new bool[num + 1];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            primes[0] = primes[1] = false;

            for (int i = 2; i <= num; i++)
            {
                if (!primes[i])
                {
                    continue;
                }
                Console.Write(i + " ");
                for (int p = 2 * i; p <= num; p += i)
                {
                    primes[p] = false;
                }
            }
            Console.WriteLine();
        }
    }
}
