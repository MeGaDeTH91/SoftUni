using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> seekWords = new List<string>();
            
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            string text = string.Empty;

            using(var seekReader = new StreamReader("../inputs/words.txt"))
            {
                string line;
                while ((line = seekReader.ReadLine()) != null)
                {
                    seekWords.Add(line);
                }
            }

            foreach (var seekWord in seekWords)
            {
                wordFrequency.Add(seekWord, 0);
            }

            using(var reader = new StreamReader("../inputs/text.txt"))
            {

                string line;
                StringBuilder sb = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
                text = sb.ToString();
            }

            List<string> textArr = text
                                   .Split(new string[] {" ", Environment.NewLine, "-", ".", ", ", "!", "?", "_" },StringSplitOptions.RemoveEmptyEntries)
                                   .ToList();

            foreach (var word in textArr)
            {
                foreach (var seekWord in seekWords)
                {
                    if (AreWordsSame(seekWord, word))
                    {
                        wordFrequency[seekWord]++;
                    }
                }
            }
            

            using (var writer = new StreamWriter("../outputs/result.txt"))
            {
                foreach (var wordCount in wordFrequency.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                }
            }
        }

        private static bool AreWordsSame(string seekWord, string word)
        {
            return seekWord.Equals(word, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
