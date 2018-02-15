using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EngNameLastDigi
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string engWord = GetEngName(n);
            Console.WriteLine(engWord);
        }
        static string GetEngName(long n)
        {
            string engWord = string.Empty;
            long lastDigit = Math.Abs(n % 10);
            switch (lastDigit)
            {
                case 0:
                    engWord = "zero";
                    break;
                case 1:
                    engWord = "one";
                    break;
                case 2:
                    engWord = "two";
                    break;
                case 3:
                    engWord = "three";
                    break;
                case 4:
                    engWord = "four";
                    break;
                case 5:
                    engWord = "five";
                    break;
                case 6:
                    engWord = "six";
                    break;
                case 7:
                    engWord = "seven";
                    break;
                case 8:
                    engWord = "eight";
                    break;
                case 9:
                    engWord = "nine";
                    break;
                default:
                    break;
            }
            return engWord;
        }
    }
}
