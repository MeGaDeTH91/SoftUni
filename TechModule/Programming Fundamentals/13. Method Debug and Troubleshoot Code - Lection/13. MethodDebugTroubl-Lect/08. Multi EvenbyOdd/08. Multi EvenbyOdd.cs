using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multi_EvenbyOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = GetMultiplyOfEvenAndOdds(n);
            Console.WriteLine(result);
        }
        static int GetMultiplyOfEvenAndOdds(int n)
        {
            int evens = 0;
            int odds = 0;
            int tempValue = Math.Abs(n);
            while (tempValue > 0)
            {
                if(tempValue % 2 == 0)
                {
                    evens = evens + tempValue % 10;
                }
                else
                {
                    odds = odds + tempValue % 10;
                }
                tempValue /= 10;
            }
            int result = evens * odds;

            return result;
        }
    }
}
