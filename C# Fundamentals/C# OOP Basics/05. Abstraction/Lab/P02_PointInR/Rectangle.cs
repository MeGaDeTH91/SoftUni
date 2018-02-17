using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BotRight { get; set; }

    public Rectangle()
    {
        TopLeft = new Point();
        BotRight = new Point();
    }

    public bool Contains(Point point)
    {
        return point.X >= this.TopLeft.X && point.X <= this.BotRight.X &&
               point.Y >= this.TopLeft.Y && point.Y <= this.BotRight.Y;
    }
}
