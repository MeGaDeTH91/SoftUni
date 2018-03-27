using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<string> inputLines = new List<string>();

        for (int i = 0; i < lines; i++)
        {
            string currLine = Console.ReadLine();

            inputLines.Add(currLine);
        }

        string compareElement = Console.ReadLine();

        Console.WriteLine(CountGreaterStrings<string>(inputLines, compareElement));
    }

    public static int CountGreaterStrings<T>(List<T> elements, T checkElement) where T : IComparable<T>
    {
        int count = 0;
        foreach (var el in elements)
        {
            if(el.CompareTo(checkElement) > 0)
            {
                count++;
            }
        }

        return count;
    }
}
