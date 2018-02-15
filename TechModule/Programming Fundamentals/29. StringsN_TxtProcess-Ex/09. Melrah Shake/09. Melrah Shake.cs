using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string key = Console.ReadLine();

            while (true)
            {
                var firstIndex = input.IndexOf(key);
                var lastIndex = input.LastIndexOf(key);

                var firstIndexExists = firstIndex != -1;
                var lastIndexExists = lastIndex != -1;

                var equalIndexex = firstIndex == lastIndex;
                var keyIsNotEmpty = key != string.Empty;
                if(!equalIndexex && firstIndexExists && lastIndexExists && keyIsNotEmpty)
                {
                    input = input.Remove(lastIndex, key.Length);
                    input = input.Remove(firstIndex, key.Length);
                    var removeChar = key.Length / 2;
                    key = key.Remove(removeChar, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    return;
                }
            }
        }
    }
}
