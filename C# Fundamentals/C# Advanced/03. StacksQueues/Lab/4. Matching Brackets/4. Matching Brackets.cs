using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> stackExp = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                char currentChar = expression[index];

                if(currentChar == '(')
                {
                    stackExp.Push(index);
                }
                else if(currentChar == ')')
                {
                    int startIndex = stackExp.Pop();
                    int length = index - startIndex + 1;
                    string content = expression.Substring(startIndex, length);

                    Console.WriteLine(content);
                }
            }
        }
    }
}
