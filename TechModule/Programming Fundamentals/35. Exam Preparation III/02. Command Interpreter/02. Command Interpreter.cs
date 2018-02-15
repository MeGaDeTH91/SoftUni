using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringArr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string commands = Console.ReadLine();
            List<string> resultList = new List<string>();
            while (commands != "end")
            {
                string[] commandArr = commands.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currCommand = commandArr[0].ToLower();
                if (currCommand == "reverse")
                {
                    int stIndex = int.Parse(commandArr[2]);
                    int count = int.Parse(commandArr[4]);
                    List<string> temp = new List<string>();
                    if (count >= 0 && stIndex >= 0 && stIndex + count <= stringArr.Count)
                    {  
                            for (int i = stIndex; i < stIndex + count; i++)
                            {
                                temp.Add(stringArr[i]);
                            }
                            temp.Reverse();
                            for (int i = 0; i < count; i++)
                            {
                                stringArr.RemoveAt(stIndex);
                            }
                            stringArr.InsertRange(stIndex, temp);
                    }
                    else
                    {
                 
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (currCommand == "sort")
                {
                    int stIndex = int.Parse(commandArr[2]);
                    int count = int.Parse(commandArr[4]);
                    List<string> temp = new List<string>();
                    if (count >= 0 && stIndex >= 0 && stIndex + count <= stringArr.Count)
                    {
                            for (int i = stIndex; i < stIndex + count; i++)
                            {
                                temp.Add(stringArr[i]);
                            }
                            temp.Sort();
                            for (int i = 0; i < count; i++)
                            {
                                stringArr.RemoveAt(stIndex);
                            }
                            stringArr.InsertRange(stIndex, temp);
                    }
                    else
                    {
                        
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (currCommand == "rollleft")
                {
                    int count = int.Parse(commandArr[1]) % stringArr.Count;
                    if (count >= 0)
                    {
                            List<string> temp = new List<string>();
                            for (int i = 0; i < count; i++)
                            {
                                string firstEl = stringArr[0];
                                for (int j = 0; j < stringArr.Count; j++)
                                {
                                    if (j + 1 < stringArr.Count)
                                    {

                                        stringArr[j] = stringArr[j + 1];
                                    }
                                    else
                                    {
                                        stringArr[j] = firstEl;
                                    }
                                }
                            }
                    }
                    else
                    {
                       
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (currCommand == "rollright")
                {
                    int count = int.Parse(commandArr[1]) % stringArr.Count;
                    if (count >= 0)
                    {
                       
                            List<string> temp = new List<string>();
                            for (int i = 0; i < count; i++)
                            {
                                string lastEl = stringArr[stringArr.Count - 1];
                                for (int j = stringArr.Count - 1; j >= 0; j--)
                                {
                                    if (j - 1 >= 0)
                                    {
                                        stringArr[j] = stringArr[j - 1];
                                    }
                                    else
                                    {
                                        stringArr[j] = lastEl;
                                    }
                                }
                            }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                commands = Console.ReadLine();
            }
            Console.Write("[");
            for (int i = 0; i < stringArr.Count; i++)
            {
                if (i == stringArr.Count - 1)
                {
                    Console.Write($"{stringArr[i]}");
                }
                else
                {
                    Console.Write($"{stringArr[i]}, ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
