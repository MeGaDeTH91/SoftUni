using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            int currentLine = int.Parse(Console.ReadLine());

            Box<int> currentBox = new Box<int>(currentLine);

            Console.WriteLine(currentBox);
        }
    }
}
