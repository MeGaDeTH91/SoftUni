using System;

public class Rectangle1
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public double TopLeftX { get; set; }
    public double TopLeftY { get; set; }

    public Rectangle1()
    {

    }
    public Rectangle1(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = Math.Abs(width);
        this.Height = Math.Abs(height);
        this.TopLeftX = x;
        this.TopLeftY = y;
    }

    public bool TheyIntersect(Rectangle1 rectangle)
    {
        double firstLeftBorder = this.TopLeftX;
        double firstTopBorder = this.TopLeftY;
        double firstBotBorder = firstTopBorder - this.Height;
        double firstRightBorder = firstLeftBorder + this.Width;

        double secondLeftBorder = rectangle.TopLeftX;
        double secondTopBorder = rectangle.TopLeftY;
        double secondBotBorder = secondTopBorder - rectangle.Height;
        double secondRightBorder = secondLeftBorder + rectangle.Width;

        return secondRightBorder >= firstLeftBorder &&
               secondLeftBorder <= firstRightBorder &&
               secondTopBorder >= firstBotBorder &&
               secondBotBorder <= firstTopBorder;

    }
}
