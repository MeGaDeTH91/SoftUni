using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("2. Input.txt");
            List<string> output = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                
                    output.Add($"{i + 1}. " + input[i]);
                
            }
            File.WriteAllLines("2. Output.txt", output);
        }
    }
}
