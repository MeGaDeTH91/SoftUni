namespace _1._Reverse_Strings
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] strings = input.Split(' ');

            Stack<string> reversed = new Stack<string>();

            foreach (var item in strings)
            {
                char[] currentCh = item.ToCharArray();
                currentCh =currentCh.Reverse().ToArray();
                string currWord = new string(currentCh);
                reversed.Push(currWord);
            }

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}
