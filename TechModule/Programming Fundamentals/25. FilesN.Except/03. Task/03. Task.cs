using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").ToLower().Split();
            string[] inputArr = File.ReadAllText("3. Input.txt").ToLower()
                .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordReg = new Dictionary<string, int>();

            foreach (var item in words)
            {
                wordReg[item] = 0;
            }
            foreach (var item in inputArr)
            {
                if(wordReg.ContainsKey(item))
                {
                    wordReg[item]++;
                }
            }
            string final = string.Empty;
            foreach (var item in wordReg.OrderByDescending(x => x.Value))
            {
                var result = ($"{item.Key}-{item.Value}");
                 final += result + Environment.NewLine;
                
            }
            File.AppendAllText("3. Output.txt", final);
        }
    }
}
