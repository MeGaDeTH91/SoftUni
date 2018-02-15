using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            var randomGenerator = new Random();
            
            for (int i = 0; i < words.Length; i++)
            {
                int randomNum = randomGenerator.Next(words.Length); // до 100
                var old = words[i];
                words[i] = words[randomNum];
                words[randomNum] = old;
            }
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
