using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SentenctheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string numType = Console.ReadLine();
            byte n = byte.Parse(Console.ReadLine());

            decimal sentence = 0.0m;
            decimal tempSent = 0.0m;
            long maxValue = long.MinValue;
            for (int i = 1; i <= n; i++)
            {
                long diffIDs = long.Parse(Console.ReadLine());
                long currValue = diffIDs;
                if ((numType == "sbyte") && (diffIDs >= sbyte.MinValue && diffIDs <= sbyte.MaxValue))
                {

                    maxValue = Math.Max(currValue, maxValue);
                }
                else if ((numType == "int") && (diffIDs >= int.MinValue && diffIDs <= int.MaxValue))
                {
                    maxValue = Math.Max(diffIDs, maxValue);
                }
                else if ((numType == "long") && (diffIDs >= long.MinValue && diffIDs <= long.MaxValue))
                {
                    maxValue = Math.Max(diffIDs, maxValue);
                }
            }
            if(maxValue < 0)
            {
                tempSent = Math.Abs(maxValue / -128m);
                sentence = Math.Ceiling(tempSent);
            }
            else if (maxValue > 0)
            {
                tempSent = maxValue / 127m;
                sentence = Math.Ceiling(tempSent);
            }
            if (sentence > 1)
            {
                Console.WriteLine($"Prisoner with id {maxValue} is sentenced to {sentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {maxValue} is sentenced to {sentence} year");
            }
          
        }
    }
}
