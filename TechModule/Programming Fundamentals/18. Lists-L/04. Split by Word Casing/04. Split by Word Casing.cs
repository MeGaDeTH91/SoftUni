using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '\\', '[', ']'};
            string[] words = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
            foreach (var word in words)
            {
                bool isAllLowerCase = true;
                bool isAllUpperCase = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if(char.IsLower(word[i]))
                    {
                        isAllUpperCase = false;
                    }
                    else if (char.IsUpper(word[i]))
                    {
                        isAllLowerCase = false;
                    }
                    else
                    {
                        isAllUpperCase = false;
                        isAllLowerCase = false;
                    }
                }
                if(isAllLowerCase)
                {
                    lowerCase.Add(word);
                }
                else if (isAllUpperCase)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }
            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));
        }
    }
}
