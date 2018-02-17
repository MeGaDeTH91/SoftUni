using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public void ParseCommand()
    {
        var commParse = new CommandParser();
        commParse.ParseCommand(this.Repo);

    }
}
