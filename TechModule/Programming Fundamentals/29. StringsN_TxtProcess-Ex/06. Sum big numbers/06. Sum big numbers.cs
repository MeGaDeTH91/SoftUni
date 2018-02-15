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
            char[] secondNum = Console.ReadLine().TrimStart(new char[] { '0' })
                .ToArray();

            List<string> result = new List<string>();

            string Sum = string.Empty;
            if(firstNum.Length == secondNum.Length)
            {
                int firstDigit = 0;
                int secondDigit = 0;
                int currSum = 0;
                int naUm = 0;

                for (int i = firstNum.Length - 1; i >= 0; i--)
                {
                    firstDigit = int.Parse(firstNum[i].ToString());
                    secondDigit = int.Parse(secondNum[i].ToString());
                    currSum = firstDigit + secondDigit + naUm;
                    naUm = 0;
                    if (currSum >= 10)
                    {
                        naUm = currSum / 10;
                        currSum = currSum % 10;
                        
                    }
                    result.Add(currSum.ToString());
                }
                result.Reverse();
            }
            else if(firstNum.Length > secondNum.Length)
            {
                int firstDigit = 0;
                int secondDigit = 0;
                int currSum = 0;
                int naUm = 0;
                int diff = firstNum.Length - secondNum.Length;

                List<char> firstNumTemp = new List<char>();

                for (int i = firstNum.Length - 1; i >= diff; i--)
                {
                    firstNumTemp.Add(firstNum[i]);
                }
                firstNumTemp.Reverse();
                for (int i = secondNum.Length - 1; i >= 0; i--)
                {
                    firstDigit = int.Parse(firstNumTemp[i].ToString());
                    secondDigit = int.Parse(secondNum[i].ToString());
                    currSum = firstDigit + secondDigit + naUm;
                    naUm = 0;
                    if (currSum >= 10)
                    {
                        naUm = currSum / 10;
                        currSum = currSum % 10;
                    }
                    result.Add(currSum.ToString());
                }
                for (int i = diff - 1; i >= 0; i--)
                {
                    if (i == diff - 1)
                    {
                        var firstAdd = naUm + int.Parse(firstNum[i].ToString());
                        naUm = 0;
                        if (firstAdd >= 10)
                        {
                            naUm = firstAdd / 10;
                            firstAdd = firstAdd % 10;
                        }
                        result.Add(firstAdd.ToString());
                    }
                    else
                    {
                        var otherAdd = naUm + int.Parse(firstNum[i].ToString());
                        if (otherAdd >= 10 && i != 0)
                        {
                            naUm = otherAdd / 10;
                            otherAdd = otherAdd % 10;
                        }

                        result.Add(otherAdd.ToString());
                    }
                }
                result.Reverse();
            }
            else
            {
                long firstDigit = 0;
                long secondDigit = 0;
                long currSum = 0;
                long naUm = 0;
                int diff = secondNum.Length - firstNum.Length;

                List<char> secondNumTemp = new List<char>();

                for (int i = secondNum.Length - 1; i >= diff; i--)
                {
                    secondNumTemp.Add(secondNum[i]);
                }
                secondNumTemp.Reverse();
                for (int i = firstNum.Length - 1; i >= 0; i--)
                {
                    firstDigit = int.Parse(firstNum[i].ToString());
                    secondDigit = int.Parse(secondNumTemp[i].ToString());
                    currSum = firstDigit + secondDigit + naUm;
                    naUm = 0;
                    if (currSum >= 10)
                    {
                        naUm = currSum / 10;
                        currSum = currSum % 10;
                    }
                    result.Add(currSum.ToString());
                }
                for (int i = diff -1; i >= 0; i--)
                {
                    if(i == diff - 1)
                    {
                        var firstAdd = naUm + int.Parse(secondNum[i].ToString());
                        naUm = 0;
                        if (firstAdd >= 10)
                        {
                            naUm = firstAdd / 10;
                            firstAdd = firstAdd % 10;
                        }
                        result.Add(firstAdd.ToString());
                    }
                    else
                    {
                        var otherAdd = naUm + int.Parse(secondNum[i].ToString());
                        if (otherAdd >= 10 && i != 0)
                        {
                            naUm = otherAdd / 10;
                            otherAdd = otherAdd % 10;
                        }
                       
                        result.Add(otherAdd.ToString());
                    }
                }
                result.Reverse();
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
