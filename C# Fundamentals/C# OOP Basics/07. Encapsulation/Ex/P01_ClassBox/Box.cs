using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double SurfaceArea()
    {
        //2lw + 2lh + 2wh
        return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double LateralSurfaceArea()
    {
        //2lh + 2wh
        return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double Volume()
    {
        //lwh
        return this.Length * this.Width * this.Height;
    }

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
    }
    public double Width
    {
        get
        {
            return this.width;
        }
    }
    public double Height
    {
        get
        {
            return this.height;
        }
    }
}
