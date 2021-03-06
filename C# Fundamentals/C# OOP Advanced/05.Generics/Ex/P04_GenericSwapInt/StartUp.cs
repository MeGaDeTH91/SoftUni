﻿using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<int> inputLines = new List<int>();

        for (int i = 0; i < lines; i++)
        {
            int currNum = int.Parse(Console.ReadLine());

            inputLines.Add(currNum);
        }
        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        SwapElements<int>(inputLines, firstIndex, secondIndex);

        foreach (var element in inputLines)
        {
            Box<int> currentBox = new Box<int>(element);

            Console.WriteLine(currentBox);
        }


    }

    private static void SwapElements<T>(List<T> elements, int firstIndex, int secondIndex)
    {
        T tempElement = elements[firstIndex];
        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = tempElement;
    }
}
