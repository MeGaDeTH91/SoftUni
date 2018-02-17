using System;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        PrintRow(n);
    }

    public static void PrintRow(int n)
    {
        // Draw first half
        for (int row = 0; row < n; row++)
        {
            var spaces = new string(' ', n - 1 - row);
            Console.Write(spaces);

            for (int col = 0; col <= row; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        // Draw second half
        for (int row = 0; row < n - 1; row++)
        {
            var spaces = new string(' ', 1 + row);
            Console.Write(spaces);

            for (int col = n - 1 - row; col > 0; col--)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}

