using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.Punctuation_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string readTxt = File.ReadAllText("input.txt");
            List<string> input = readTxt.Split(' ').ToList();
            List<char> charList = new List<char>();
            string final = string.Empty;
            for (int i = 0; i < input.Count; i++)
            {
                string currWord = input[i];

                for (int j = 0; j < currWord.Length; j++)
                {
                   if (currWord[j] != '.' && currWord[j] != ',' && currWord[j] != '!' && currWord[j] != '?' && currWord[j] != ':')
                    {
                        final += currWord[j];
                    } 
                }
                final += " ";
            }
            File.WriteAllText("output.txt", final);
            Console.WriteLine(final);

        }
    }
}
