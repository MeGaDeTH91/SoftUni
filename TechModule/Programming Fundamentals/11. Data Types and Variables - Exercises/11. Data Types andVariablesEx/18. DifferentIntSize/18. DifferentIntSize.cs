using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _18.DifferentIntSize
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger b = BigInteger.Parse(Console.ReadLine());
            long a = 0;
            try
            {
                if ((b >= long.MinValue) && (b <= long.MaxValue))
                {
                    long temp = (long)b;
                    a = temp;
                }
                if ((b < long.MinValue) || (b > long.MaxValue))
                {
                    throw new Exception();
                }
                Console.WriteLine($"{a} can fit in:");
                if (a >= -128 && a <= 127)
                {
                    Console.WriteLine("* sbyte");
                }
                if (a >= 0 && a <= 255)
                {
                    Console.WriteLine("* byte");
                }
                if (a >= -32768 && a <= 32767)
                {
                    Console.WriteLine("* short");
                }
                if (a >= 0 && a <= 65535)
                {
                    Console.WriteLine("* ushort");
                }
                if (a >= int.MinValue && a <= int.MaxValue)
                {
                    Console.WriteLine("* int");
                }
                if (a >= uint.MinValue && a <= uint.MaxValue)
                {
                    Console.WriteLine("* uint");
                }
                if (a >= long.MinValue && a <= long.MaxValue)
                {
                    Console.WriteLine("* long");
                }
                
            }
            catch (Exception)
            {
                
                Console.WriteLine($"{b} can't fit in any type");
            }
        }
    }
}
