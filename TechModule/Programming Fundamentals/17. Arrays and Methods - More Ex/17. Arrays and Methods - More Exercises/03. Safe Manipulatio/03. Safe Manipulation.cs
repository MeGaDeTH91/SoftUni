using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Safe_Manipulatio
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
           


            int len = arr.Length;
            for (int i = 1; i <= 100; i++)
            {
                string[] action = Console.ReadLine().Split(' ').ToArray();
                if (action.Length == 1)
                {
                    if (action[0] == "Reverse")
                    {
                        Array.Reverse(arr);
                    }
                    else if (action[0] == "Distinct")
                    {

                        string[] unique = arr.Distinct().ToArray();
                        arr = unique;
                    }
                    else if(action[0] == "END")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    if(action[0] == "Replace")
                    {
                        int replaceIndex = int.Parse(action[1]);
                        if (replaceIndex < 0 || replaceIndex >= arr.Length)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            string newWord = action[2];
                            arr[replaceIndex] = newWord;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
