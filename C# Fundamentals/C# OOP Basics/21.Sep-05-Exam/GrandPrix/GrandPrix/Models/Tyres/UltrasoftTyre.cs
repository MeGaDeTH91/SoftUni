using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public double Grip
    {
        get { return grip; }
        protected set { grip = value; }
    }

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Name = "Ultrasoft";
        this.Grip = grip;
    }

    public override void DegradateTire()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if(value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }
}
