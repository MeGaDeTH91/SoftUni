using System;

public class Rectangle : IDrawable
{
    private double width;
    private double height;

    public double Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        private set { this.height = value; }
    }

    public Rectangle(double Width, double Height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void Draw()
    {
        DrawLine(this.Width, '*', '*');
        for (int i = 1; i < this.Height - 1; i++)
        {
            DrawLine(this.Width, '*', ' ');
        }
        DrawLine(this.Width, '*', '*');
    }

    private void DrawLine(double width, char end, char mid)
    {
        Console.Write(end);
        for (int i = 1; i < width - 1; i++)
        {
            Console.Write(mid);
        }
        Console.WriteLine(end);
    }
}