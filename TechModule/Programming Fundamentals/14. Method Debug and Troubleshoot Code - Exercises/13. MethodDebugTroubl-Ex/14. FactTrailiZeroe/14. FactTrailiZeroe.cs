using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _14.FactTrailiZeroe
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger result = GetFactorial(num);
            long zeroNum = GetZeroNumber(result);
            Console.WriteLine(zeroNum);
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
        static long GetZeroNumber(BigInteger result)
        {
            long zeroNum = 0;
            while (result > 0)
            {
                if (result % 10 == 0)
                {
                    zeroNum++;
                }
                else if (zeroNum > 0 && result % 10 > 0)
                {
                    return zeroNum;
                }
                result /= 10;
            }
            return zeroNum;
        }
    }
}
