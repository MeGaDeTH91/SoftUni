using System;
using System.Collections.Generic;
using System.Text;

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price):base(author, title, price)
    {
        this.Price = price;
    }
    protected override decimal Price
    {
        get
        {
            return base.Price * 1.30m;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Type: GoldenEditionBook");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:F2}");

        return sb.ToString().TrimEnd();
    }
}
