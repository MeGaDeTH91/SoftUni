using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    public Square Square { get; set; }
    public Rectangle Rectangle { get; set; }

    public DrawingTool(Square currSquare)
    {
        this.Square = currSquare;
    }
    public DrawingTool(Rectangle currRectangle)
    {
        this.Rectangle = currRectangle;
    }
}

