using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Extract_Sentences_by_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separators = new string[] { ".", "!", "?" };
            string keyWord = Console.ReadLine().ToLower();
            string[] text = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int sentence = 0; sentence < text.Length; sentence++)
            {
                string[] result = text[sentence].Split(new char[] { ',', ':', '(', ')', '[', ']', '\"', '\'', '/', '\\', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (result.Contains(keyWord))
                {
                    Console.WriteLine(text[sentence].Trim());
                }
            }
        }
    }
}
