using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string commandInput = Console.ReadLine();
            while (commandInput != "end")
            {
                string[] commArr = commandInput.Split().ToArray();
                string currCommand = commArr[0].ToLower();
                if (currCommand == "exchange")   // Exchange
                {
                    int currIndex = int.Parse(commArr[1]);
                    if (!IsIndexValid(inputNums, currIndex))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        int takeNum = currIndex + 1;
                        int takeSecond = inputNums.Count ;
                        List<int> firstArr = new List<int>(inputNums.Take(takeNum).ToList());
                        List<int> secondArr = new List<int>(inputNums.Skip(takeNum).Take(takeSecond).ToList());
                        inputNums = new List<int>(secondArr.Concat(firstArr).ToList());
                    }
                }
                else if (currCommand == "max")     // Max
                {
                    string evenOrOdd = commArr[1].ToLower();
                    if (evenOrOdd == "even")
                    {
                        int maxEven = 0;
                        int maxEvenKey = 0;
                        Dictionary<int, int> evenList = new Dictionary<int, int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 == 0)
                            {
                                evenList[inputNums[i]] = i;
                            }
                        }

                        if (evenList.Count > 0)
                        {
                            maxEvenKey = evenList.Keys.Max();
                            maxEven = evenList[maxEvenKey];
                            Console.WriteLine(maxEven);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    if (evenOrOdd == "odd")
                    {
                        int maxOdd = 0;
                        int maxOddKey = 0;
                        Dictionary<int, int> oddList = new Dictionary<int, int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 != 0)
                            {
                                oddList[inputNums[i]] = i;
                            }
                        }
                        if (oddList.Count > 0)
                        {
                            maxOddKey = oddList.Keys.Max();
                            maxOdd = oddList[maxOddKey];
                            Console.WriteLine(maxOdd);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }
                else if (currCommand == "min")  // Min
                {
                    string evenOrOdd = commArr[1].ToLower();
                    if (evenOrOdd == "even")
                    {
                        int minEvenKey = 0;
                        int minEven = 0;
                        Dictionary<int, int> evenList = new Dictionary<int, int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 == 0)
                            {
                                evenList[inputNums[i]] = i;
                            }
                        }

                        if (evenList.Count > 0)
                        {
                            minEvenKey = evenList.Keys.Min();
                            minEven = evenList[minEvenKey];
                            Console.WriteLine(minEven);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    if (evenOrOdd == "odd")
                    {
                        int minOddKey = 0;
                        int minOdd = 0;
                        Dictionary<int, int> oddList = new Dictionary<int, int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 != 0)
                            {
                                oddList[inputNums[i]] = i;
                            }
                        }
                        if (oddList.Count > 0)
                        {
                            minOddKey = oddList.Keys.Min();
                            minOdd = oddList[minOddKey];
                            Console.WriteLine(minOdd);
                        }
                        else
                        {  
                            Console.WriteLine("No matches");
                        }
                    }
                }
                else if (currCommand == "first")  //First
                {
                    int numCount = int.Parse(commArr[1]);
                    string evenOrOdd = commArr[2].ToLower();
                    if (evenOrOdd == "even")
                    {
                        List<int> evenList = new List<int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 == 0)
                            {
                                evenList.Add(inputNums[i]);
                            }
                        }
                        if(numCount > inputNums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        else if (evenList.Count > 0)
                        {
                            int border = Math.Min(numCount, evenList.Count);
                            Console.Write("[");

                            for (int i = 0; i < border; i++)
                            {
                                if (i == border - 1)
                                {
                                    Console.Write($"{evenList[i]}");
                                }
                                else
                                {
                                    Console.Write($"{evenList[i]}, ");
                                }
                            }
                            Console.WriteLine("]");
                        }
                        else if (evenList.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                    }
                    else if (evenOrOdd == "odd")
                    {
                        List<int> oddList = new List<int>();
                        for (int i = 0; i < inputNums.Count; i++)
                        {
                            if (inputNums[i] % 2 != 0)
                            {
                                oddList.Add(inputNums[i]);
                            }
                        }
                        if(numCount > inputNums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        else if (oddList.Count > 0)
                        {
                            int border = Math.Min(numCount, oddList.Count);
                            Console.Write("[");

                            for (int i = 0; i < border; i++)
                            {
                                if (i == border - 1)
                                {
                                    Console.Write($"{oddList[i]}");
                                }
                                else
                                {
                                    Console.Write($"{oddList[i]}, ");
                                }
                            }
                            Console.WriteLine("]");
                        }
                        else if (oddList.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        
                    }
                }
                else if (currCommand == "last")  //Last
                {
                    int numCount = int.Parse(commArr[1]);
                    string evenOrOdd = commArr[2].ToLower();
                    List<int> reversed = new List<int>(inputNums);
                    reversed.Reverse();
                    if (evenOrOdd == "even")
                    {
                        List<int> evenList = new List<int>();
                        for (int i = 0; i < reversed.Count; i++)
                        {
                            if (reversed[i] % 2 == 0)
                            {
                                evenList.Add(reversed[i]);
                            }
                        }
                        List<int> final = evenList.Take(numCount).ToList();
                        final.Reverse();
                        if(numCount > inputNums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        if (evenList.Count > 0)
                        {
                            int border = Math.Min(numCount, evenList.Count);
                            Console.Write("[");
                            for (int i = 0; i < border; i++)
                            {
                                if (i == border - 1)
                                {
                                    Console.Write($"{final[i]}");
                                }
                                else
                                {
                                    Console.Write($"{final[i]}, ");
                                }
                            }
                            Console.WriteLine("]");
                        }
                        else if (evenList.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        

                    }
                    else if (evenOrOdd == "odd")
                    {

                        List<int> oddList = new List<int>();
                        for (int i = 0; i < reversed.Count; i++)
                        {
                            if (reversed[i] % 2 != 0)
                            {
                                oddList.Add(reversed[i]);
                            }
                        }
                        List<int> final = oddList.Take(numCount).ToList();
                        final.Reverse();
                        if(numCount > inputNums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        else if (oddList.Count > 0)
                        {
                            int border = Math.Min(numCount, final.Count);
                            Console.Write("[");

                            for (int i = 0; i < border; i++)
                            {
                                if (i == border - 1)
                                {
                                    Console.Write($"{final[i]}");
                                }
                                else
                                {
                                    Console.Write($"{final[i]}, ");
                                }
                            }
                            Console.WriteLine("]");
                        }
                        else if (oddList.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        
                    }
                }

                commandInput = Console.ReadLine();
            }
            Console.Write("[");
            for (int i = 0; i < inputNums.Count; i++)
            {
                if (i == inputNums.Count - 1)
                {
                    Console.Write($"{inputNums[i]}");
                }
                else
                {
                    Console.Write($"{inputNums[i]}, ");
                }
            }
            Console.WriteLine("]");
        }

        private static bool IsIndexValid(List<int> inputNums, int currIndex)
        {
            return currIndex >= 0 && currIndex < inputNums.Count;
        }
    }
}
