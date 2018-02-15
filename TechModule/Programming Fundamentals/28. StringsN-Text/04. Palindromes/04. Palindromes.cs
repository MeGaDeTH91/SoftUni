using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = Console.ReadLine()
                .Split(new char[] {' ', ',', '!', '?', '.'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
           List<string> checkedWords = CheckForPalindrome(inputTxt);
            Console.WriteLine(string.Join(", ", checkedWords.OrderBy(x => x)));

        }

        private static List<string> CheckForPalindrome(string[] input)
        {
            StringBuilder sb = new StringBuilder();
            List<string> palindromes = new List<string>();
            foreach (var word in input)
            {
                sb = new StringBuilder();
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sb.Append(word[i]);
                }
                var reversed = sb.ToString();
                if(reversed == word)
                {
                    palindromes.Add(reversed);
                }
            }
            palindromes = palindromes.Distinct().ToList();
            return palindromes;
        }
    }
}
