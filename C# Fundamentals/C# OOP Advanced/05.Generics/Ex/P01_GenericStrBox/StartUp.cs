using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string currentLine = Console.ReadLine();

            Box<string> currentBox = new Box<string>(currentLine);

            Console.WriteLine(currentBox);
        }
    }
}
