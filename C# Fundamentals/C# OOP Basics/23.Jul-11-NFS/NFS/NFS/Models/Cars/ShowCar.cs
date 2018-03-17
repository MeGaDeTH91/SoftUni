using System;
using System.Text;

public class ShowCar : Car
{
    private int stars;

    public int Stars
    {
        get { return this.stars; }
        protected set { this.stars = value; }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        int horsePowerIncrease = tuneIndex;
        int suspensionIncrease = tuneIndex / 2;
        this.Horsepower += horsePowerIncrease;
        this.Suspension += suspensionIncrease;
        this.Stars += tuneIndex;
    }

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString().Trim();
    }
}
