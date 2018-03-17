using System;

public abstract class Monument
{
    private string name;
    private int affinity;

    protected Monument(string name, int affinity)
    {
        this.Name = name;
        this.Affinity = affinity;
    }

    public int Affinity
    {
        get { return this.affinity; }
        set { this.affinity = value; }
    }
    
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public override string ToString()
    {
        string fullType = this.GetType().Name;
        string type = fullType.Substring(0, fullType.IndexOf("Monument"));

        return $"{type} Monument: {this.Name}, {type} Affinity: {this.Affinity}";
    }
}
