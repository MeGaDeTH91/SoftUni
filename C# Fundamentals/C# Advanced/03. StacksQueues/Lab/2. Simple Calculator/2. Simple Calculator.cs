using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] elements = input.Split(' ');

            elements = elements.Reverse().ToArray();

            Stack<string> operationStack = new Stack<string>();

            foreach (var ele in elements)
            {
                operationStack.Push(ele);
            }

            int result = 0;

            while (operationStack.Count > 1)
            {
                int leftOperand = int.Parse(operationStack.Pop());
                string operation = operationStack.Pop();
                int rightOperand = int.Parse(operationStack.Pop());

                switch (operation)
                {
                    case"+":
                        result = leftOperand + rightOperand;
                        operationStack.Push(result.ToString());
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        operationStack.Push(result.ToString());
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
