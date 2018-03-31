using System;

public class ConnectedArea : IComparable<ConnectedArea>
{
    public int AreaNumber { get; set; }

    public int Row { get; set; }
    public int Col { get; set; }

    public ConnectedArea(int xPosition, int yPosition)
    {
        this.Row = xPosition;
        this.Col = yPosition;
    }

    public int Size { get; set; }

    public override string ToString()
    {
        return $"Area #{this.AreaNumber} at ({this.Row}, {this.Col}), size: {this.Size}";
    }

    public int CompareTo(ConnectedArea other)
    {
        int result = other.Size.CompareTo(this.Size);
        if (result == 0)
        {
            result = this.Row.CompareTo(other.Row);
        }
        if (result == 0)
        {
            result = this.Col.CompareTo(other.Col); 
        }

        return result;
    }
}
