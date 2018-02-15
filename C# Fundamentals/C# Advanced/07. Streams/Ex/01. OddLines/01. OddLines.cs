using System;
using System.IO;

namespace _01._OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var stream = new StreamReader("..\\text.txt"))
            {
                var lineNum = 1;

                string line = stream.ReadLine();

                while (line != null)
                {
                    if(lineNum % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNum++;

                    line = stream.ReadLine();
                }
            }
        }
    }
}
