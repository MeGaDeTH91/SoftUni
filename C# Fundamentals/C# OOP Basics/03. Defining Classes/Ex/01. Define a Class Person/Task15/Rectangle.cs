using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public int Width { get; set; }
    public int Length { get; set; }

    public Rectangle()
    {

    }

    public Rectangle(int width, int length)
    {
        this.Width = width;
        this.Length = length;
    }
    public void Draw()
    {
        for (int i = 0; i < this.Length; i++)
        {
            if (i == 0 || i == this.Length - 1)
            {
                Console.WriteLine($"|{new string('-', this.Width)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', this.Width)}|");
            }
        }
    }
}
