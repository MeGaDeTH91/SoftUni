using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumsReverseOrd
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            GetReversedNum(word);
            //Console.WriteLine(reversed);
        }
        static void GetReversedNum(string word)
        {
            Console.WriteLine(string.Join("", word.Reverse()));
            //string reversed = string.Empty; // С масиви
            //string output = "";
            //for (int i = word.Length - 1; i >= 0; i--)
            //{
            //    output += word[i];
            //}
            //reversed = output;
            //return reversed;
        }
    }
}
