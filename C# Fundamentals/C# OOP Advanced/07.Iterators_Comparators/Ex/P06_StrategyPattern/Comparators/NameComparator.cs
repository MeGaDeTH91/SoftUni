using System;
using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);

        if(result == 0)
        {
            string xFirstLetter = x.Name.ToLower()[0].ToString();
            string yFirstLetter = y.Name.ToLower()[0].ToString();

            result = xFirstLetter.CompareTo(yFirstLetter);
        }
        return result;
    }
}
