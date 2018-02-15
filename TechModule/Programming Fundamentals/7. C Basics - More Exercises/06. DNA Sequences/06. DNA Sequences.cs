using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int matchSum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        string wrap = i + j + k >= matchSum ? "O" : "X";
                        Console.Write($"{wrap}{i}{j}{k}{wrap} "
                            .Replace("1", "A")
                            .Replace("2", "C")
                            .Replace("3", "G")
                            .Replace("4", "T"));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
