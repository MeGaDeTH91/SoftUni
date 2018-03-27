using System;
using System.Collections.Generic;
using System.Linq;

public class Sorter 
{
    public static void Sort<T>(CustomList<T> elements) where T : IComparable<T>
    {
        elements.Sort();
    }
}
