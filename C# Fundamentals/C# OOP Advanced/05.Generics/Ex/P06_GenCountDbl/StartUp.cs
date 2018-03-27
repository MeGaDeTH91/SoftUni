using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int lineNumber = int.Parse(Console.ReadLine());
        List<double> numbers = new List<double>();

        for (int i = 0; i < lineNumber; i++)
        {
            double currentNum = double.Parse(Console.ReadLine());

            numbers.Add(currentNum);
        }
        double compareNum = double.Parse(Console.ReadLine());

        Console.WriteLine(CountGreaterNumbers<double>(numbers, compareNum));
    }

    public static int CountGreaterNumbers<T>(List<T> elements, T element) where T : IComparable<T>
    {
        int count = 0;

        foreach (var el in elements)
        {
            if(el.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
}