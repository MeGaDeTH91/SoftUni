using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var bannWord in bannedWords)
            {
                if(text.Contains(bannWord))
                {
                    text = text.Replace(bannWord, new string('*', bannWord.Length));
                }
            }
            Console.WriteLine(text);
        }
    }
}
