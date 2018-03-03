using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model { get => model; set => model = value; }
    public string Color { get => color; set => color = value; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} Seat {this.Model}");
        sb.AppendLine(Start());
        sb.AppendLine(Stop());
        return sb.ToString().TrimEnd();
    }
}