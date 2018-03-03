using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public Human()
    {

    }

    protected string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            char firstLetter = value[0];
            if(!char.IsLetter(firstLetter) || !char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if(string.IsNullOrWhiteSpace(value) || value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }
    protected string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            char firstLetter = value[0];
            if (!char.IsLetter(firstLetter) || !char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");

        return sb.ToString().TrimEnd();
    }
}