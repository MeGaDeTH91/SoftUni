using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    private static Stack<int> source = new Stack<int>();
    private static Stack<int> spare = new Stack<int>();
    private static Stack<int> destination = new Stack<int>();

    private static int steps = 1;
    

    static void Main(string[] args)
    {
        int numberOfDisks = int.Parse(Console.ReadLine());
        source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
        PrintInitialHanoi();

        MoveDisks(numberOfDisks, source, destination, spare);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (bottomDisk == 1)
        {
            destination.Push(source.Pop());
            PrintCurrentHanoi();
            steps++;
        }
        else
        {
            MoveDisks(bottomDisk - 1, source, spare, destination);
            destination.Push(source.Pop());

            PrintCurrentHanoi();
            steps++;
            MoveDisks(bottomDisk - 1, spare, destination, source);
        }
    }

    private static void PrintCurrentHanoi()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Step #{steps}: Moved disk");
        sb.AppendLine($"Source: {string.Join(", ", source.Reverse())}");
        sb.AppendLine($"Destination: {string.Join(", ", destination.Reverse())}");
        sb.AppendLine($"Spare: {string.Join(", ", spare.Reverse())}");

        Console.WriteLine(sb.ToString());
    }

    private static void PrintInitialHanoi()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Source: {string.Join(", ", source.Reverse())}");
        sb.AppendLine($"Destination: {string.Join(", ", destination.Reverse())}");
        sb.AppendLine($"Spare: {string.Join(", ", spare.Reverse())}");

        Console.WriteLine(sb.ToString());
    }
}
