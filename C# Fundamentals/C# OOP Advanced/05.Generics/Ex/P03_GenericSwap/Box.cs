using System;

public class Box<T>
{
    T Value;

    public Box(T value)
    {
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{Value.GetType().FullName}: {Value}";
    }
}
