using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int res = 0;

            list.Add(1000);
            res += 1000;
            list.Add(10000);
            res += 10000;
            list.Add(0);
            res += 0;
            list.Add(0);
            res += 0;
            

            double floored = Math.Floor(list.Average());
            int fored = 0;
            for (int i = 0; i < list.Count; i++)
            {
                fored += list[i];
            }
            int average = fored / list.Count;
            int integered = res / list.Count;
            Console.WriteLine(floored);
            Console.WriteLine(integered);
            Console.WriteLine(average);
        }
    }
}