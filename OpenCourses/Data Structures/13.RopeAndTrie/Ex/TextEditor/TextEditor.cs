using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class TextEditor : ITextEditor
{
    private Trie<BigList<string>> users;
    private Dictionary<string, Stack<BigList<string>>> cache;

    public TextEditor()
    {
        this.users = new Trie<BigList<string>>();
        this.cache = new Dictionary<string, Stack<BigList<string>>>();
    }

    public void Clear(string username)
    {
        throw new NotImplementedException();
    }

    public void Delete(string username, int startIndex, int length)
    {
        throw new NotImplementedException();
    }

    public void Insert(string username, int index, string str)
    {
        throw new NotImplementedException();
    }

    public int Length(string username)
    {
        throw new NotImplementedException();
    }

    public void Login(string username)
    {
        throw new NotImplementedException();
    }

    public void Logout(string username)
    {
        throw new NotImplementedException();
    }

    public void Prepend(string username, string str)
    {
        throw new NotImplementedException();
    }

    public string Print(string username)
    {
        throw new NotImplementedException();
    }

    public void Substring(string username, int startIndex, int length)
    {
        throw new NotImplementedException();
    }

    public void Undo(string username)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> Users(string prefix = "")
    {
        throw new NotImplementedException();
    }
}
