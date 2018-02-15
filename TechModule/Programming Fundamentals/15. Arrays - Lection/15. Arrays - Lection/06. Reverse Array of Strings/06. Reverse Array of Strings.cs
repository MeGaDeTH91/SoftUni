using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            string[] array = letters.Split(' ');
            string reverse = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i];
                
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
