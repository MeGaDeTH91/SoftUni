using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var stream = new StreamReader("../inputs/text.txt"))
            {
                using(var writer = new StreamWriter("../outputs/output.txt"))
                {
                    int lineNumber = 1;

                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        writer.Write($"Line {lineNumber}: {line}");
                        writer.WriteLine();
                        lineNumber++;
                    }
                }                
            }
        }
    }
}
