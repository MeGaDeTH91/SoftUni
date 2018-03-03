using System;
using System.Text;

public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public int CodeNumber
    {
        get { return codeNumber; }
        private set { codeNumber = value; }
    }

    public Spy(int id, string firstName, string lastName, int codeNum) : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNum;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
        sb.AppendLine($"Code Number: {this.CodeNumber}");
        return sb.ToString().TrimEnd();
    }
}