using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine());

            int len = arr.Length;
            for (int i = 1; i <= n; i++)
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
                }
                else
                {
                    int replaceIndex = int.Parse(action[1]);
                    string newWord = action[2];
                    arr[replaceIndex] = newWord;
                }

            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }   
}
