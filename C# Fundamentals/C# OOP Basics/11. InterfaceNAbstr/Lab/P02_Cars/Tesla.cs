using System.Text;

public class Tesla : ICar, IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int batteries)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = batteries;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public int Battery
    {
        get { return this.battery; }
        private set
        {
            this.battery = value;
        }
    }
    public string Model
    {
        get { return model; }
        private set
        {
            model = value;
        }
    }
    public string Color
    {
        get { return color; }
        private set
        {
            color = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(Start());
        sb.AppendLine(Stop());
        return sb.ToString().TrimEnd();
    }
}