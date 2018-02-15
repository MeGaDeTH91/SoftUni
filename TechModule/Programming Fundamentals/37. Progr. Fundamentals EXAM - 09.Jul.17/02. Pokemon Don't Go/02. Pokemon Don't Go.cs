using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numArr = Console.ReadLine()
                .Split().Select(long.Parse)
                .ToList();

            long sumOfRemoved = 0;
            bool valid = false;
            bool lessThanZero = false;
            bool moreThanList = false;
            if(numArr.Count > 0)
            {
                while (true)
                {
                    if (numArr.Count == 0)
                    {
                        Console.WriteLine(sumOfRemoved);
                        return;
                    }
                    int removeIndex = int.Parse(Console.ReadLine());
                    valid = CheckIfIndexIsValid(removeIndex, numArr);
                    lessThanZero = CheckIfIndexIsLess(removeIndex, numArr);
                    moreThanList = CheckIfIndexIsGreater(removeIndex, numArr);
                    long currRemoveNum = 0;

                    if (valid)
                    {
                        currRemoveNum = numArr[removeIndex];
                        sumOfRemoved += numArr[removeIndex];
                        numArr.RemoveAt(removeIndex);
                        for (int i = 0; i < numArr.Count; i++)
                        {
                            if(numArr[i] <= currRemoveNum)
                            {
                                numArr[i] += currRemoveNum;
                            }
                            else if(numArr[i] > currRemoveNum)
                            {
                                numArr[i] -= currRemoveNum;
                            }
                        }
                    }
                    else if(lessThanZero)
                    {
                        currRemoveNum = numArr[0];
                        sumOfRemoved += numArr[0];
                        numArr.RemoveAt(0);
                        for (int i = 0; i < numArr.Count; i++)
                        {
                            if (numArr[i] <= currRemoveNum)
                            {
                                numArr[i] += currRemoveNum;
                            }
                            else if (numArr[i] > currRemoveNum)
                            {
                                numArr[i] -= currRemoveNum;
                            }
                        }
                        numArr.Insert(0, numArr[numArr.Count - 1]);
                    }
                    else if(moreThanList)
                    {
                        currRemoveNum = numArr[numArr.Count- 1];
                        sumOfRemoved += numArr[numArr.Count - 1];
                        numArr.RemoveAt(numArr.Count - 1);
                        for (int i = 0; i < numArr.Count; i++)
                        {
                            if (numArr[i] <= currRemoveNum)
                            {
                                numArr[i] += currRemoveNum;
                            }
                            else if (numArr[i] > currRemoveNum)
                            {
                                numArr[i] -= currRemoveNum;
                            }
                        }
                        numArr.Add(numArr[0]);
                    }
                }
            }
            else
            {
                Console.WriteLine(sumOfRemoved);
            }
        }

        private static bool CheckIfIndexIsValid(int removeIndex, List<long> numArr)
        {
            var result = removeIndex >= 0 && removeIndex < numArr.Count;
            return result;
        }
        private static bool CheckIfIndexIsGreater(int removeIndex, List<long> numArr)
        {
            var result = removeIndex >= numArr.Count;
            return result;
        }
        private static bool CheckIfIndexIsLess(int removeIndex, List<long> numArr)
        {
            var result = removeIndex < 0;
            return result;
        }
    }
}
