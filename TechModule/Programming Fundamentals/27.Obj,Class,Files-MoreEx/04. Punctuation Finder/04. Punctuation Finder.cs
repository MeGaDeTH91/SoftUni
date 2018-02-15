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
            string[] input = readTxt.Split(' ').ToArray();
            List<char> charList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                string currWord = input[i];

                for (int j = 0; j < currWord.Length; j++)
                {
                    if(currWord[j] == '.' || currWord[j] == ',' || currWord[j] == '!' || currWord[j] == '?' || currWord[j] == ':')
                    {
                        charList.Add(currWord[j]);
                    }
                }
            }
            File.WriteAllText("output.txt", string.Join(", ", charList));
            Console.WriteLine(string.Join(", ", charList));
            
        }
    }
}
