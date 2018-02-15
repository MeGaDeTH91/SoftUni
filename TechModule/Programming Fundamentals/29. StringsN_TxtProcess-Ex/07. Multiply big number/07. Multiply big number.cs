using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_big_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstNum = Console.ReadLine().TrimStart(new char[] { '0' })
                .ToArray();
            int secondNum = int.Parse(Console.ReadLine());
            if( secondNum == 0)
            {
                Console.WriteLine("0");
                return;
            }
            List<string> result = new List<string>();
                int firstDigit = 0;
                int secondDigit = 0;
                int currSum = 0;
                int naUm = 0;
                for (int i = firstNum.Length - 1; i >= 0; i--)
                {
                    firstDigit = int.Parse(firstNum[i].ToString());
                    secondDigit = secondNum;
                    currSum = firstDigit * secondDigit + naUm;
                    naUm = 0;
                    if (currSum >= 10)
                    {
                        naUm = currSum / 10;
                        currSum = currSum % 10;
                    }
                    result.Add(currSum.ToString());
                }
             if(naUm > 0)
            {
                result.Add(naUm.ToString());
            }    
            result.Reverse(); 
            Console.WriteLine(string.Join("", result));
        }
    }
}
