using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var output = new StringBuilder();

            File.WriteAllText("output.txt", output.ToString());
        }
    }
}
