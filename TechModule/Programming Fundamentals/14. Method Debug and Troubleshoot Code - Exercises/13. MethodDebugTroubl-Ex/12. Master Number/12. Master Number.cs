using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());

            for (long i = 1; i <= num; i++)
            {
                if (IfPalindrome(i) && IfSumIsDivBy7(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
            
        }
        static bool IfPalindrome(long num)
        {
            long lastDigit = num % 10;
            long firstDigit = 0;
            long currNum = num;
            while (currNum > 0)
            {
                firstDigit = currNum % 10;
                currNum /= 10;
            }
            if(lastDigit != firstDigit)
            {
                return false;
            }
            else
            {
                string str = num.ToString();
                string reverseNum = string.Join("", str.Reverse());
            
             if (str == reverseNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        static bool IfSumIsDivBy7(long num)
        {
            long tempNum = num;
            long currDigit = 0;
            long sum = 0;
            while (tempNum > 0)
            {
                currDigit = tempNum % 10;
                sum += currDigit;
                tempNum /= 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        static bool ContainsEvenDigit(long num)
        {
            long tempNum = num;
            long currDigit = 0;
           
            while (tempNum > 0)
            {
                currDigit = tempNum % 10;
                if (currDigit % 2 == 0)
                {
                    return true;
                }
                tempNum /= 10;
            }
           
                return false;
            
        }
    }
}
