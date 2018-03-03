﻿using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }
    public Book()
    {

    }

    protected string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    protected string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            string[] names = value.Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);

            if(names.Length > 1)
            {
                if (char.IsDigit(names[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }            
            this.author = value;
        }
    }
    protected virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Type: Book");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:F2}");
        
        return sb.ToString().TrimEnd();
    }
}