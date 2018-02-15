using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> oddList = new List<int>();
            List<int> evenList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                if(command.Length == 1)
                {
                    if(command[0] == "Odd")
                    {
                        for (int j = 0; j < nums.Count; j++)
                        {
                            if(nums[j] % 2 > 0)
                            {
                                oddList.Add(nums[j]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", oddList));
                        return;
                    }
                    else
                    {
                        for (int j = 0; j < nums.Count; j++)
                        {
                            if (nums[j] % 2 == 0)
                            {
                                evenList.Add(nums[j]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", evenList));
                        return;
                    }
                }
                else if (command.Length == 2)
                {
                    int deleteElement = int.Parse(command[1]);
                    for (int k = 0; k < nums.Count; k++)
                    {
                        nums.Remove(deleteElement);
                    }
                    
                }
                else 
                {
                    int insertElement = int.Parse(command[1]);
                    int insertIndex = int.Parse(command[2]);
                    nums.Insert(insertIndex, insertElement);
                }
            }

        }
    }
}
