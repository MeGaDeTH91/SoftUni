using System;
using System.Text;

public class Ferrari : IFerrari
{
    private string model;
    private string driver;

    public Ferrari(string model, string driver)
    {
        this.Model = model;
        this.Driver = driver;
    }

    public string Model {
        get
        {
            return this.model;
        }
        private set
        {
            this.model = value;
        }
    }

    public string Driver
    {
        get
        {
            return this.driver;
        }
        private set
        {
            this.driver = value;
        }
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}");

        return sb.ToString().TrimEnd();
    }
}
