using System;
using System.Collections.Generic;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();
            brackets.Push(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(' ||
                   currentChar == '[' ||
                   currentChar == '{')
                {
                    brackets.Push(input[i]);
                }

                else if (brackets.Count == 0 && (currentChar == ')' ||
                        currentChar == '}' ||
                        currentChar == ']'))
                {
                    Console.WriteLine("NO");
                    return;
                }

                if (currentChar == ')')
                {
                    char brack = brackets.Pop();
                    if (brack != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (currentChar == '}')
                {
                    char brack = brackets.Pop();
                    if (brack != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if(currentChar == ']')
                {
                    char brack = brackets.Pop();
                    if (brack != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

            }

            Console.WriteLine("YES");
        }
    }
}
