using System;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100.0d; 
    }

    public virtual void DegradateTire()
    {
        this.Degradation -= this.Hardness;
    }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if(value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }


    public double Hardness
    {
        get { return hardness; }
        protected set { hardness = value; }
    }


    public string Name
    {
        get { return this.name; }
        protected set
        {
            this.name = value;
        }
    }
}
