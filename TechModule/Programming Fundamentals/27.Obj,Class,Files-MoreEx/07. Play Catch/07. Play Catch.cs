using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse).ToList();

            int counter = 0;
            while (counter < 3)
            {
                string[] currInput = Console.ReadLine()
                    .Split(' ').ToArray();
                if (currInput.Length == 3)
                {
                    string command = currInput[0];
                    int indOrStIndex = 0;
                    int elemOrEndIndex = 0;
                    try
                    {
                        int temp1 = int.Parse(currInput[1]);
                        int temp2 = int.Parse(currInput[2]);
                        indOrStIndex = temp1;
                        elemOrEndIndex = temp2;
                    }
                    catch (Exception)
                    {
                        
                        counter++;
                        Console.WriteLine("The variable is not in the correct format!");
                        break;
                    }
                    
                    if (command == "Replace")
                    {
                        try
                        {
                            nums.RemoveAt(indOrStIndex);
                            nums.Insert(indOrStIndex, elemOrEndIndex);
                        }
                        catch (Exception)
                        {
                            counter++;
                            if (indOrStIndex < 0 || indOrStIndex >= nums.Count)
                            {
                                Console.WriteLine("The index does not exist!");
                            }

                        }
                    }
                    else if (command == "Print")
                    {
                        try
                        {
                            
                            int startTemp = nums[indOrStIndex];
                            int endTemp = nums[elemOrEndIndex];
                            if(startTemp > endTemp)
                            {
                                throw new Exception();
                            }
                            for (int i = indOrStIndex; i <= elemOrEndIndex; i++)
                            {
                                if (i == elemOrEndIndex)
                                {
                                    Console.Write($"{nums[i]}");
                                }
                                else
                                {
                                    Console.Write($"{nums[i]}, ");
                                }

                            }
                            Console.WriteLine();
                        }
                        catch (Exception)
                        {
                            counter++;
                            if ((indOrStIndex < 0 || indOrStIndex >= nums.Count) || (elemOrEndIndex < 0 || elemOrEndIndex >= nums.Count))
                            {
                                Console.WriteLine("The index does not exist!");
                            }
                        }
                    }
                }

                else
                {
                    string command = currInput[0];
                    int number = 0;
                    bool index = int.TryParse(currInput[1], out number);
                    try
                    {
                        if (index)
                        {
                            Console.WriteLine(nums[number]);
                        }
                        else
                        {
                            counter++;
                            Console.WriteLine("The variable is not in the correct format!");
                        }
                    }
                    catch (Exception)
                    {
                        if (number < 0 || number >= nums.Count)
                        {
                            Console.WriteLine("The index does not exist!");

                        }
                        counter++;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}