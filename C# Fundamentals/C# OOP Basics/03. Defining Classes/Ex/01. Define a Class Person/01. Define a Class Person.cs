using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        string command = Console.ReadLine();

        if(command == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            Square currSq = new Square()
            {
                Size = size
            };
            DrawingTool newDraw = new DrawingTool(currSq);
            newDraw.Square.Draw();
        }
        else if(command == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            Rectangle currRectangle = new Rectangle()
            {
                Width = width,
                Length = length
            };
            DrawingTool newDraw = new DrawingTool(currRectangle);
            newDraw.Rectangle.Draw();
        }
    }
}


