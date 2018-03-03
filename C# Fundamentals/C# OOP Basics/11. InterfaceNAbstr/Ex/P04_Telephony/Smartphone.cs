using System;
using System.Text;

public class Smartphone : ICall, IBrowse
{
    public string Model { get; set; }
    private string[] numbers;
    private string[] urls;

    public string[] Numbers {
        get
        {
            return this.numbers;
        }
        set
        {
            this.numbers = value;
        }
    }
    public string[] Urls
    {
        get
        {
            return this.urls;
        }
        set
        {
            this.urls = value;
        }
    }

    public Smartphone(string model, string[] numbers, string[] urls)
    {
        this.Model = model;
        this.Numbers = numbers;
        this.Urls = urls;
    }
    
    public string Call(string number)
    {
        if(this.IsNumberValid(number))
        {
            return $"Calling... {number}";
        }
        else
        {
            return $"Invalid number!";
        }
        
    }    
    public string Browse(string url)
    {
        if(this.IsValidUrl(url))
        {
            return $"Browsing: {url}!";
        }
        else
        {
            return $"Invalid URL!";
        }        
    }

    private bool IsNumberValid(string number)
    {
        foreach (char current in number)
        {
            if (!char.IsDigit(current))
            {
                return false;
            }
        }
        return true;
    }
    private bool IsValidUrl(string url)
    {
        foreach (char current in url)
        {
            if (char.IsDigit(current))
            {
                return false;
            }
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var num in this.Numbers)
        {
            sb.AppendLine(this.Call(num));
        }
        foreach (var url in this.Urls)
        {
            sb.AppendLine(this.Browse(url));
        }
        return sb.ToString().TrimEnd();
    }
}
