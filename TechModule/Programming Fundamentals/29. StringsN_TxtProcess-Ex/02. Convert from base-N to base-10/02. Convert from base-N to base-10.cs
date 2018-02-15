using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine()
                .Split().ToArray();
            int currentSys = int.Parse(input[0]);
            char[] num = input[1].Reverse().ToArray();

            BigInteger sum = new BigInteger();

            for (int power = 0; power < num.Length; power++)
            {
                int currNum = int.Parse(num[power].ToString());
                sum += currNum * BigInteger.Pow(currentSys, power);
            }
            Console.WriteLine(sum);
        }
    }
}
