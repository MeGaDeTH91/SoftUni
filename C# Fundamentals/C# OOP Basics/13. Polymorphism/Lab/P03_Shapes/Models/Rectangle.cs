using System;

public class Rectangle : Shape
{
    private double sideA;
    private double sideB;

    public Rectangle(double sideA, double sideB)
    {
        this.SideA = sideA;
        this.SideB = sideB;
    }

    public double SideB
    {
        get { return sideB; }
        private set { sideB = value; }
    }


    public double SideA
    {
        get { return sideA; }
        private set { sideA = value; }
    }

    public override double CalculateArea()
    {
        return this.SideA * this.SideB;
    }

    public override double CalculatePerimeter()
    {
        return this.SideA * 2 + this.SideB * 2;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle"; 
    }
}
