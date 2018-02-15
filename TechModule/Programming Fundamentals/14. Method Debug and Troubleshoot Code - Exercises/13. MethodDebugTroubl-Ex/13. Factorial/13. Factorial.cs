using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger result = GetFactorial(num);
            Console.WriteLine(result);
        }
        static BigInteger GetFactorial(int num)
        {
            BigInteger result = 1;
            for (int i = num; i > 1; i--)
            {
                result = result * i;
            }
            return result;
        }
    }
}
