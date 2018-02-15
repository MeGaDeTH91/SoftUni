using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Working_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("1. Input.txt");
            List<string> output = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 > 0)
                {
                    output.Add(input[i]);
                }
            }
            File.WriteAllLines("1. Output.txt", output);
        }
    }
}
