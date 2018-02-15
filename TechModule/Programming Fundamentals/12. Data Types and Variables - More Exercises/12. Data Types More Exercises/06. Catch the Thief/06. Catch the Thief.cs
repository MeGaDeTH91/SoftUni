using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string numType = Console.ReadLine();
            byte n = byte.Parse(Console.ReadLine());

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
                else if((numType == "long") && (diffIDs >= long.MinValue && diffIDs <= long.MaxValue))
                {
                    maxValue = Math.Max(diffIDs, maxValue);
                }
            }
            Console.WriteLine(maxValue);
        }
    }
}
