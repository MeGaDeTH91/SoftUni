using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine()
                .Split().Select(BigInteger.Parse).ToArray();
            BigInteger desiredSys = input[0];
            BigInteger num = input[1];
            List<string> newNum = new List<string>();

            while (num > 0)
            {
                string newLeft = (num % desiredSys).ToString();
                newNum.Add(newLeft);
                num /= desiredSys;
            }
            List<string> reverse = new List<string>();
            for (int i = newNum.Count - 1; i >= 0; i--)
            {
                reverse.Add(newNum[i]);
            }
            Console.WriteLine(string.Join("", reverse));
        }
    }
}
