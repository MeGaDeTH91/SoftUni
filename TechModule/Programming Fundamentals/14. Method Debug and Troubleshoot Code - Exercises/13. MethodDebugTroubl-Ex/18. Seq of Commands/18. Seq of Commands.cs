using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        
        for (int i = 0; i <= 20; i++)
        {
            string[] command = Console.ReadLine().Split(ArgumentsDelimiter).ToArray();
            if(command[0] == "stop")
            {
                
                return;
            }
           
            int[] args = new int[2];

            if (command[0].Equals("add") ||
                command[0].Equals("subtract") ||
                command[0].Equals("multiply"))
            {
                
                args[0] = int.Parse(command[1]);
                args[1] = int.Parse(command[2]);

                PerformAction(array, command, args);
                PrintArray(array);
            }
            else if(command[0].Equals("rshift") ||
                command[0].Equals("lshift"))
            {
                PerformAction(array, command, args);
                PrintArray(array);
            }


        }
        //PrintArray(array);

    }

    static void PerformAction(long[] arr, string[] command, int[] args)
    {
        long[] array = arr;
        
        int pos = args[0];
        int value = args[1];

        switch (command[0])
        {
            case "multiply":
                array[pos - 1] *= value;
                break;
            case "add":
                array[pos - 1] += value;
                break;
            case "subtract":
                array[pos - 1] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
        }
    }

    private static void ArrayShiftRight(long[] arr)
    {
        long lastElement = arr[arr.Length - 1];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[0] = lastElement;
    }

    private static void ArrayShiftLeft(long[] arr)
    {
        long firstElement = arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[arr.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
