using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class WeaponAttribute : Attribute
{
    private string author = "Pesho";
    private int revision = 3;
    private string description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
    private string[] reviewers = { "Pesho", "Svetlio" };

    public WeaponAttribute()
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers;
    }

    public string Author { get; private set; }

    public int Revision { get; private set; }

    public string Description { get; private set; }

    public string[] Reviewers { get; private set; }
}
