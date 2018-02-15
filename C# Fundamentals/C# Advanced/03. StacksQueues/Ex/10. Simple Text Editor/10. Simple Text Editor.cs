using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operataionNumber = int.Parse(Console.ReadLine());

            string resultText = string.Empty;

            Stack<string> undoStack = new Stack<string>();

            for (int i = 0; i < operataionNumber; i++)
            {
                string[] commArr = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int commandType = int.Parse(commArr[0]);

                switch (commandType)
                {
                    case 1:
                        StringBuilder sb = new StringBuilder();
                        sb.Append(commArr[1]);
                        undoStack.Push(resultText);

                        resultText = string.Concat(resultText, sb.ToString());
                        break;
                    case 2:
                        int countElements = int.Parse(commArr[1]);
                        int startIndex = resultText.Length - countElements;
                        StringBuilder deletedTxt = new StringBuilder();
                        deletedTxt.Append(resultText.Substring(startIndex, countElements));
                        undoStack.Push(resultText);

                        resultText = resultText.Substring(0, startIndex);
                        break;
                    case 3:
                        int index = int.Parse(commArr[1]);
                        char desired = resultText[index - 1];

                        Console.WriteLine(desired.ToString());
                        break;
                    case 4:
                        resultText = undoStack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
