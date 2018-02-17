using System;
using System.Collections.Generic;
using System.Text;

public class Square
{
    public int Size { get; set; }

    public Square()
    {

    }

    public Square(int size)
    {
        this.Size = size;
    }

    public void Draw()
    {
        for (int i = 0; i < this.Size; i++)
        {
            if(i == 0 || i == this.Size - 1)
            {
                Console.WriteLine($"|{new string('-', this.Size)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', this.Size)}|");
            }
        }
    }
}
